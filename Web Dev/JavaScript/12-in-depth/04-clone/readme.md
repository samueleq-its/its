# 4.Clone
## Author
samuele.querio@edu-its.it

## Requirements
Write a function `clone()` that clones any object
- Test it on the object in the next slide
- Change the name of the cloned object and make sure that the original did not change
**Important:**
Write the function yourself, do not use built-in functions such as `Object.assign()`, `jQuery.extend()` or
`JSON.parse(JSON.stringify())`  
The object to clone and test:

```javascript
{
name: 'Green Mueller',
email: 'Rigoberto_Muller47@yahoo.com',
address: '575 Aiden Forks',
bio: 'Tenetur voluptatem odit labore et voluptatem vel qui placeat sit.',
active: false,
salary: 37993,
birth: Sun Apr 18 1965 13:38:00 GMT+0200 (W. Europe Daylight Time),
bankInformation:
{ amount: '802.04',
date: Thu Feb 02 2012 00:00:00 GMT+0100 (W. Europe Standard Time),
business: 'Bernhard, Kuhn and Stehr',
name: 'Investment Account 8624',
type: 'payment',
account: '34889694' }
}
```

## Approach to solution