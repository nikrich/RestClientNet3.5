# RestClientNet3.5
.NET 3.5 Rest Client library for getting and manipulating json data

## Installation
```
git clone https://github.com/nikrich/RestClientNet3.5.git
```
Install the packages via Nuget

## Usage
#### Create a DAO
```
public class Person
{
    public string firstName { get; set; }
}
```

#### Get the data from your Restful API
```
  string URL = "http://your.base.url/";
  Dictionary<string, string> parameters = new Dictionary<string, string>
  {
      {"id", "1"}
  };
  string result = apiHelper.Get(URL, "person", parameters); //BASEURL, RESOURCE, PARAMS
  IList<Person> person = jsonHelper.From<Person>(result);
```

