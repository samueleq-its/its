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