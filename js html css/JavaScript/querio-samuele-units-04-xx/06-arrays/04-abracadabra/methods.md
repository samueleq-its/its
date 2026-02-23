# Methods used to replace the 4th letter

- Solution 1: Uses `slice` to take the substring before the target index, appends 'X', then appends the substring after the target index.

- Solution 2: Converts the string to an array with `split`, assign 'X' at index 3, then `join` back to a string.

- Solution 3: Uses a regular expression to match the fist 4 characters and capture the first 3.  
Keeps the first 3 characters with a backreference and replaces the fourth character with 'X'
