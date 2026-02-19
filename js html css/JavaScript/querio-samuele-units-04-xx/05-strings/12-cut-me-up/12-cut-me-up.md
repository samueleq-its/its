### slice(start,end)
**Slice** is a method of a string that returns the portion of string contained between the index passed as first rgument and either the index passed as second argument or the end of the string if only 1 argument is passed.  
If an argument is negative it's counted backward.  
The first argument is inclusive, the second is non inclusive.

```javascript
let a = "hello world";

a.slice();     // return: "hello world"
a.slice(3); 	// return: "lo world"
a.slice(-3); 	// return: "rld"
a.slice(1,3); 	// return: "el"
a.slice(5,4);	// return: ""
```

### substring(start,end)
**Substring** works similarly to **slice** except when the first parameter is greater than the second or when either paramenters are negative.

```javascript
let a = "hello world";

a.slice(5,2);   // return: ""
// if argument for start is greater than end they are swapped
a.subtring(5,2); // return: "llo"

a.slice(-5,2);      // return: ""
// if either arguments are negative or 'NaN' they are treated as if they were 0
a.substring(-5,2);  // return: "he"
```

### substr(start,lenght)
**Substr** is a deprecated method and should therefore be avoided if possible.  
Unlike the first two methods, the second parameter of substr doesn't indicate the ending position in the string but the lenght of substring to return.  
Negative values of start will count backward like in **slice** while negative values of lenght are treated as 0.

```javascript
let a = "hello world";
a.slice(2,3);   // return: "l"
a.substr(2,3);  // return: "llo"
```