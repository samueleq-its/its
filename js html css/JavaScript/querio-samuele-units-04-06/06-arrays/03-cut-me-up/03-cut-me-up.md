## slice() vs splice()
**slice(start, end)**  
It's a method of an Array object that returns the elements of the array found between array[start] (included) and array[end] (not included, optional)  

**splice(start, deleteCount, item1, item2, ..., itemN)**  
It's a method of an Array object that directly alters the array, removing, replacing or adding elements  
*start* indicates the starting position in the array, if it's negative counts backward from the end of the array  
*deleteCount* (optional) indicates the number of elements to be deleted from *start*, if omitted and there's only *start*, deletes every element from start to the end of the array  
*item1, ...* (optional) list of items to add to the array from start  
returns an array with all the removed items

```javascript
let list = ["a","b","c","d","e"]
let sliceResult = list.slice(-3,5)      // sliceResult: ["c", "d", "e"], list: ["a","b","c","d","e"]
let spliceResult = list.splice(-3,3)    // spliceResult: ["c", "d", "e"], list: ["a","b"]

spliceResult = list.splice(2,0,"C", "D", "E")   // spliceResult: [], list: ["a", "b", "C", "D", "E"]

```