# 6.Parity Cipher

## Author
samuele.querio@edu-its.it

## Requirements

Write a function to reconstruct a hidden sentence by sorting a scrambled array of objects

**Rule 1 (Parity)**
all characters with even rank numbers must come before characters with odd rank numbers

**Rule 2 (Value)**
within the even and odd groups, characters must be sorted by their rank in ascending order

**Return value:** the hidden sentence as a string

### Example:
``` javascript
const exampleCipher = [
 { char: "n", rank: 3 },
 { char: "h", rank: 1 },
 { char: "o", rank: 2 },
 { char: "j", rank: 0 }
];
Return value: "john"
```


### Cipher:
```javascript
6.Parity Cipher
const cipher = [
 { char: "e", rank: 8 }, { char: " ", rank: 10 }, { char: "s", rank: 12 },
 { char: "o", rank: 14 }, { char: "l", rank: 16 }, { char: "e", rank: 18 },
 { char: " ", rank: 20 }, { char: "f", rank: 22 }, { char: "a", rank: 24 },
 { char: "m", rank: 26 }, { char: "i", rank: 1 }, { char: "u", rank: 2 },
 { char: "t", rank: 3 }, { char: "t", rank: 4 }, { char: "l", rank: 5 },
 { char: "a", rank: 7 }, { char: "n", rank: 9 }, { char: "m", rank: 11 },
 { char: "a", rank: 13 }, { char: "t", rank: 15 }, { char: "i", rank: 17 },
 { char: "o", rank: 19 }, { char: "n", rank: 21 }, { char: "a", rank: 0 },
 { char: "c", rank: 6 }, { char: "h", rank: 23 }, { char: "i", rank: 25 },
 { char: "d", rank: 27 }, { char: "r", rank: 29 }
];
```