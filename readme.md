# PageSharp
This is a light weight utility to help with paging a collection and then iterate over the pages.

You create a new pager by calling the Create() method
```
var pages = new Pager<YourClass>.Create(pageSize: 100, collection: myCollection)
```


## Example
```

using PageSharp;
...
public class MyClass{
    pubilc void MyMethod(){
        var pager = Pager<string>.Create(pageSize: 3, collection: new List<string> { "", "", "", "" });
        do{
            var page = pager.GetNextPage();
            // DO STUFF
        }while(pager.HasPages);
    }
}


```

One of the use cases I've found this useful for is when you want to batch calls to a web service asyncronously, but don't want to have to handle the paging algorithim

