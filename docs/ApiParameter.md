# ApiParameter<TValue>

Base class of all customizable parameter object classes.

### Namespace

Aspose.HTML.Cloud.Sdk.ApiParameters

### Public constructor

```c#
ApiParameter<TValue> (string name, TValue value)
```



### Public properties

#### Name

```c#
string Name {get; protected set; }
```

Parameter name. Read-only property.

#### Value

```c#
TValue Value {get; protected set; }
```

Parameter value. Read-only property.



# PathParameter

Abstract class that represents local or remote directory path parameter.

### Namespace

Aspose.HTML.Cloud.Sdk.ApiParameters

### Base class

ApiParameter<TValue>

### Public properties

#### Path

```c#
string Path {get; }
```

File or directory path. Read-only property.



# LocalDirectoryParameter

Class that represents a directory in the local file system.

### Namespace

Aspose.HTML.Cloud.Sdk.ApiParameters

### Base class

PathParameter

### Public constructor

```c#
LocalDirectoryParameter (string path)
```

Parameter *path* must be a valid absolute or relative local directory path.



# RemoteDirectoryParameter

Class that represents a directory in the specified or default cloud storage.

### Namespace

Aspose.HTML.Cloud.Sdk.ApiParameters

### Base class

PathParameter

### Public constructor

```c#
RemoteDirectoryParameter (string path, string storageName = null)
```

Parameter *path* must be a valid cloud storage directory path. Parameter storageName is optional, empty value means a default storage.

### Public properties

#### Storage

```c#
string Storage { get; }
```

Storage name. Empty value means the default storage. Read-only property.

#### FullPath

```c#
string FullPath { get;}
```

Full storage path in `"storage://{Storage}/{FolderPath}"` format. Read-only property.