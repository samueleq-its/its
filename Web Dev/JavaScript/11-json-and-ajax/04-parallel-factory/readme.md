# 3.Remote factory

## Author
samuele.querio@edu-its.it

## Requirements
4.Parallel factory
- Create another version of the factory that uses the same jsonblobs that you
created for the previous exercise
- Make sure that each car information is stored in a different jsonblob
- The page should display the list of cars with detailed information about
each car directly visible without a collapsible panel
- Make sure that you request all jsonblobs in parallel (at the same time) not in
sequence (one after another)
- Show a loader or a loading message while loading and show the list only
when data has returned from all jsonblobs and all requests finished
- Make sure that your code handles all errors

## Approach to solution

### jsonblobs
**NB:** the jsonblobs are automatically deleted after 3 days since the last access  
factory : [`019d3ebd-7dfa-74ca-92c4-3e3d2dcc2692`](https://www.jsonblob.com/019d3ebd-7dfa-74ca-92c4-3e3d2dcc2692)  
cars:  
[`019d4e11-8584-7a55-a9b9-7b7272a289a7`](https://www.jsonblob.com/019d4e11-8584-7a55-a9b9-7b7272a289a7)  
[`019d4e11-c59a-7177-8110-6dfd77bcf506`](https://www.jsonblob.com/019d4e11-c59a-7177-8110-6dfd77bcf506)  
[`019d4e13-0b14-71d9-9346-fbe6ccc0ea10`](https://www.jsonblob.com/019d4e13-0b14-71d9-9346-fbe6ccc0ea10)  
[`019d4e11-f153-7ba8-a97f-6892045ad5a9`](https://www.jsonblob.com/019d4e11-f153-7ba8-a97f-6892045ad5a9)  
[`019d4e12-a5f9-77b7-ae5d-e12302a98bf5`](https://www.jsonblob.com/019d4e12-a5f9-77b7-ae5d-e12302a98bf5)  
