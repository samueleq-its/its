# 3.Remote factory

## Author
samuele.querio@edu-its.it

## Requirements
- Use jsonblob to store JSON data about cars and a car factory
- You can use as many blobs as you need. Decide the structure in a way to
reduce the amount of data you modify with HTTP requests
- Write an application that displays a factory with a list of cars
- Clicking on each car should display a collapsible panel with more
information about the car
- It should be possible to edit the car details
- Save the modified data to jsonblob with an HTTP request
- Whenever data is modified you should reload the new data from jsonblob
once the writing has finished
- You should handle all error cases in your application. If an HTTP request
fails, you should display a message to the user
- Your project should include a folder called ‘json’ with all the initial json files
that you upload to jsonblob (the initial state of your DB)
- Your readme (markdown) should include links to all the jsonblobs that you
are using as well as a list of their IDs

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
