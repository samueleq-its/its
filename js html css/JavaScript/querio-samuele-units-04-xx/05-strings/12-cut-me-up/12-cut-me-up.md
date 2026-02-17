### slice()
**slice** is a method of a string that returns the portion of string contained between the index passed as first argument and either the index passed as second argument or the end of the string if only 1 argument is passed  
if an argument is negative it's counted backward  
the first argument is inclusive, the second is non inclusive

```javascript
let a = "hello world"
a.splice() 		// return: "hello world"
a.splice(3) 	// return: "lo world"
a.splice(-3) 	// return: "rld"
a.splice(1,3) 	// return: "el"
a.splice(5,4) 	// return: ""
```

### substring()
[substring](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/substring)

### substr()
[substr](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/substr)