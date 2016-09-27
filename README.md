# JSON Parser and Serializer in C# (.Net Core) #
_Holo JSON is a minimal JSON parser/builder._

It was originally created in Java (called "Mini JSON"), and now we are converting it to C#. The Java version, MiniJSON, included many interesting features that were not generally found in other JSON libraries, such as "partial parsing" and "partial serialization", etc.

The currently ported portion, the `HoloJson.Mini` and `HoloJson.Core` packages, contains the core part of the original library. It includes two basic components:
 
* Parser: Parses a JSON string into a structure comprising IDictionary&lt;string,object&gt; and IList&ltobject&gt;. 
* Builder: Builds a JSON string given an object structure comprising IDictionary&lt;string,object&gt; and IList&lt;object&gt;.

 We will work on the full port of MiniJson/HoloJson in the coming weeks/months. Meanwhile, you can install the Minimal/Core package via  NuGet:

    Install-Package HoloJson.Core


Note: `HoloJson.Core` is a port for dotnet core (C#). Moving forward, `HoloJson.Mini` will not be supported. 

