`ul li {}` weight: 0-0-2  
elements have a specificity of 0-0-1, the combinator ' ' (white space) has a weight of 0-0-0 resulting in a total of 0-0-2

`ul > li {}` weight: 0-0-2  
elements have a specificity of 0-0-1, the combinator '>' has a weight of 0-0-0 resulting in a total of 0-0-2

`body > #main.mobile a:hover {}` weight: 1-2-2  
elements (body, a) have a specificity of 0-0-1, combinators (> ' ') have a weight of 0-0-0, ids (#main) have a weight of 1-0-0, classes and speudo-classes have a weight of 0-1-0, the sum of all weights is 1-2-2

`div p > span {}` weight: 0-0-3  
elements (div, p, span) each count as 0-0-1 and the combinator '>' adds 0-0-0, totaling 0-0-3

`.users .name {}` weight: 0-2-0  
classes have a weight of 0-1-0 each and the combinator has a weight of 0-0-0, their combinations totals to 0-2-0

`[href$='.pdf'] {}` weight: 0-1-0 
attribute selectors have a weight of 0-1-0

`:hover {}` weight: 0-1-0  
pseudo-classes have a weight of 0-1-0

`div .name {}` weight: 0-1-1  
element (div) adds 0-0-1 and class (.name) adds 0-1-0 for a total of 0-1-1

`a[href$='.pdf'] {}` weight: 0-1-1  
the element a contributes 0-0-1 and the attribute selector adds 0-1-0, totaling 0-1-1

`.pictures img:hover {}` weight: 0-2-1  
classes and pseudo-classes (.pictures, :hover) are 0-1-0 each and elements(img) are 0-0-1, totaling 0-2-1

`.news.breaking.featured {}` weight: 0-3-0  
three classes (.news, .breaking, .featured) each add 0-1-0, totaling 0-3-0

`.user #name {}` weight: 1-1-0  
.user (class) adds 0-1-0 and #name (id) adds 1-0-0 for a total of 1-1-0

`#name span {}` weight: 1-0-1  
#name (id) is 1-0-0 and span (element) is 0-0-1, totaling 1-0-1

`nav#nav > li:hover {}` weight: 1-1-2  
elements (nav, li) weight 0-0-1 each, ids (#nav) weight 1-0-0 and pseudo-classes (:hover) weigh 0-1-0 for a total of 1-1-2

`li:nth-child(2n+1):hover {}` weight: 0-2-1  
li is an element (0-0-1) and the pseudo-classes :nth-child and :hover each add 0-1-0, totaling 0-2-1
