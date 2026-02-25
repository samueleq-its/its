# 5.Most specific
For each selector, calculate the specificity explain it in a markdown file: most-specific.md  
**Note:** Your explanation should be very detailed!
```css
ul li {}
ul > li {}
body > #main.mobile a:hover {}
div p > span {}
.users .name {}
[href$='.pdf'] {}
:hover {}
div .name {}
a[href$='.pdf'] {}
.pictures img:hover {}
.news.breaking.featured {}
.user #name {}
#name span {}
nav#nav > li:hover {}
li:nth-child(2n+1):hover {}
```