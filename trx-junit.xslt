<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:b="http://microsoft.com/schemas/VisualStudio/TeamTest/2010" exclude-result-prefixes="b" >
	<xsl:output method="xml" indent="yes" omit-xml-declaration="yes" />
	<xsl:template match="/">
		<xsl:variable name="numberOfTests" select="count(//b:UnitTestResult/@testId)"/>
		<xsl:variable name="numberOfFailures" select="count(//b:UnitTestResult/@outcome[.='Failed'])" />
		<xsl:variable name="numberOfErrors" select="count(//b:UnitTestResult[not(@outcome)])" />
		<xsl:variable name="numberSkipped" select="count(//b:UnitTestResult/@outcome[.!='Passed' and .!='Failed'])" />
		<testsuite tests="{$numberOfTests}" errors="{$numberOfErrors}" failures="{$numberOfFailures}" skipped="{$numberSkipped}" name="MSTestSuite">
			<xsl:text>&#xd;&#xa;</xsl:text>
			<xsl:for-each select="//b:UnitTestResult">
				<xsl:variable name="testName" select="@testName"/>
				<xsl:variable name="executionId" select="@executionId"/>
				<xsl:variable name="testId" select="@testId"/>
				<xsl:variable name="totalduration">
					<xsl:choose>
						<xsl:when test="@duration">
							<xsl:variable name="duration_seconds" select="substring(@duration, 7)"/>
							<xsl:variable name="duration_minutes" select="substring(@duration, 4,2 )"/>
							<xsl:variable name="duration_hours" select="substring(@duration, 1, 2)"/>
							<xsl:value-of select="$duration_hours*3600 + $duration_minutes*60 + $duration_seconds"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:variable name="d_seconds" select="substring(@endTime, 18,10) - substring(@startTime, 18,10)"/>
							<xsl:variable name="d_minutes" select="substring(@endTime, 15,2) - substring(@startTime, 15,2 )"/>
							<xsl:variable name="d_hours" select="substring(@endTime, 12,2) - substring(@startTime, 12, 2)"/>
							<xsl:value-of select="$d_hours*3600 + $d_minutes*60 + $d_seconds"/>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:variable>
				<xsl:variable name="outcome">
					<xsl:choose>
						<xsl:when test="@outcome = 'NotExecuted'">
							<xsl:value-of select="'Skipped'"/>
						</xsl:when>
						<xsl:when test="@outcome">
							<xsl:value-of select="@outcome"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="'Error'"/>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:variable>
				<xsl:variable name="message" select="b:Output/b:ErrorInfo/b:Message"/>
				<xsl:variable name="stacktrace" select="b:Output/b:ErrorInfo/b:StackTrace"/>
				<xsl:for-each select="//b:UnitTest">
					<xsl:variable name="currentTestId" select="@id"/>
					<xsl:if test="$currentTestId = $testId" >
						<xsl:variable name="className" select="b:TestMethod/@className"/>
						<testcase name="{$testName}" time="{$totalduration}" status="{$outcome}" classname="{$className}" >
							<xsl:if test="contains($outcome, 'Failed')">
								<xsl:text>&#xd;&#xa;</xsl:text>
								<failure message="{$message}">
									<xsl:value-of select="$stacktrace" />
								</failure>
								<xsl:text>&#xd;&#xa;</xsl:text>
							</xsl:if>
							<xsl:if test="contains($outcome, 'Skipped')">
								<xsl:text>&#xd;&#xa;</xsl:text>
								<skipped />
								<xsl:text>&#xd;&#xa;</xsl:text>
								<skipped message="{$message}" />
								<xsl:text>&#xd;&#xa;</xsl:text>
							</xsl:if>
							<xsl:if test="contains($outcome, 'Error')">
								<xsl:text>&#xd;&#xa;</xsl:text>
								<error message="{$message}">
									<xsl:value-of select="$stacktrace" />
								</error>
								<xsl:text>&#xd;&#xa;</xsl:text>
							</xsl:if>
						</testcase>
						<xsl:text>&#xd;&#xa;</xsl:text>
					</xsl:if>
				</xsl:for-each>
			</xsl:for-each>
		</testsuite>
	</xsl:template>
</xsl:stylesheet>