# 1.About me
Start with this HTML
```html
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8"/>
<title>About Me</title>
</head>
<body>
<h1>About Me</h1>
<ul>
<li>Nickname: <span id="nickname"></span></li>
<li>Favorites: <span id="favorites"></span></li>
<li>Hometown: <span id="hometown"></span></li>
</ul>
</body>
</html>
```
- Add an external javascript file called main.js
- In JavaScript:
    - Change the body style so it has a font-family of "Arial, sans-serif"
    - Replace each of the spans (nickname, favorites, hometown) with your own information
    - Iterate through each li and change the class to "list-item"
    - Create a new img element and set its src attribute to a picture of you
    - Append that element to the page
- Add an external css file using Javascript
    - The external css file should make items with the .list-item class white, bold and with an
orange background
    - The external css file should be applied after 4 seconds