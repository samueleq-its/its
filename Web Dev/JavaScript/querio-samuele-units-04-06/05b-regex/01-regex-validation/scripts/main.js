/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */


//email address
let pattern = /\S*@\S*\.[a-zA-Z]{2,4}/;
let testString = "samuele.querio@edu-its.it";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

testString = "mail: robertred1@_example.com.uk";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

//phone number
pattern = /(00|\+)?\d{0,2} ?\d(\d|-| )+/g;
testString = "0039 333 15 88 093";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

testString = "phone: +39 333-15-88-093";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

testString = "3331588093";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

//password
pattern = /(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z0-9])\S{8,}/;
testString = "password";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

testString = "Passw0rd!";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

testString = "1QqaZ2wsX3edC";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

//URL
pattern = /[a-z][a-z1-9+.-]+:[/]{2}[a-z0-9-.]*\.?[a-zA-Z]{0,4}[/][a-zA-Z0-9_.:/%-]*\?*[a-zA-Z0-9;~&=_.%/-]*#*[a-zA-Z0-9=~:*&,-]*/;

testString = "https://www.youtube.com/watch?v=xC0tctsGquI#t=5";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

testString = "https://en.wikipedia.org/wiki/URI_fragment#Examples";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

testString = "file:///C:/Users/samue/Documents/ITS/github/its/js%20html%20css/JavaScript/querio-samuele-units-04-xx/05b-regex/01-regex-validation/index.html";
console.log(`string: "${testString}"
pattern: ${pattern}
match: ${testString.match(pattern)}`);

