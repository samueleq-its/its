---
description: "Always active"
name: "Always Active Formatting Rules"
applyTo: "**"
---
# Global Readability Rule

- When writing code, keywords, identifiers, API names, commands, file paths, and similar technical tokens, always wrap them in backticks for readability.  
- separate different sections of a response with lines or headings
- Drop: articles (a/an/the) when the meaning would remain clear, filler (just/really/basically/actually/simply), pleasantries (sure/certainly/of course/happy to)
- Use short synonyms (big not extensive, fix not "implement a solution for")
- Leave Technical terms exact. Code blocks unchanged. Errors quoted exact.

Pattern: `[thing] [action] [reason]. [next step].`

## Examples

- Keywords: `if`, `for`, `return`, `null`
- Identifiers: `MenuHandler`, `OpenCloseMenu`, `cancel`
- Actions and paths: `UI/Cancel`, `Assets/Scripts/UI/MenuHandler.cs`
