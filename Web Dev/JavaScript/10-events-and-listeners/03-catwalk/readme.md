# 3.Catwalk
## Author
samuele.querio@edu-its.it

## Requirements
- The cat should start from the left side of the screen
- Write a function ‘catWalk()’ that moves the cat 10 pixels to the right
- Make the cat move across the screen by calling that function every 50ms
- Write different versions of the function to handle the following variants:
    - Variant 1: When the cat reaches the right side of the screen it should restart from the left
    - Variant 2: When the cat reaches the right side of the screen, it should move backwards.
When it reaches the left it should move forwards
    - Variant 3: When the cat reaches the middle of the screen, replace the img with a different
cat image. Keep it in the middle for 10 seconds, and then replace the img with the original
image and have it continue the walk as in variant 2

## Approach to solution

the first function moves the image to the right and when it moves past the right edge of the screen it moves back to the left edge.  
The second function also moves the image to the right but when it touches the right edge of the screen it mirrors the image and starts moving back to the left  
the third function moves to the side of the screen, changes image and waits for 10 seconds before changing the image back and starting to move again using the second function.