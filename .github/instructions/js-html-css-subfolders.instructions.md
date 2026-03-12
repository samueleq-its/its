---
name: "JS HTML CSS Subfolders Scope"
description: "Use when creating or editing files inside subfolders of 'js html css' in this workspace."
applyTo: "js html css/**/*"
---
# JS HTML CSS Workspace Instruction

- Apply these instructions only to files inside subfolders of `js html css`.
- Treat this area as learning exercises: keep solutions simple, clear, and beginner-friendly.
- Prefer minimal, focused edits that preserve existing exercise structure.
- Do not introduce extra frameworks or dependencies unless explicitly requested.
- Prefer VS Code workbench operations (file reads/edits/search tools) over terminal automation for code and content updates.
- Use terminal commands only when workbench tools cannot reasonably complete the task.

## JavaScript JSDoc Requirements

- Every `.js` file must include a file-level JSDoc comment at the top of the file using this structure:

```js
/**
 * @file: filename (e.g. main.js)
 * @author: samuele.querio@edu-its.it
 * Purpose of file - brief explanation of the purpose of the file
 *
 * Detailed explanation of what the file does
 * on multiple lines, only if the brief explanation isn't enough
 */
```

- Every regular function should include a JSDoc comment using this structure:

```js
/**
 * function description
 * @param {type} paramName description
 * @returns {type} description
 */
```

- If a function does not return anything, do not include `@returns` in its JSDoc.
- Short arrow functions do not need JSDoc.
- Do not rewrite short arrow functions into normal functions unless explicitly requested.

## Exercise Folder Creation Rules

### Folder Structure Validation

- Validate folder hierarchy using this structure:

```text
querio-samuele-units-<starting unit>-<ending unit>
	<unit id>-<unit-title>
		<exercise number>-<exercise-title>
```

- Prefer the canonical class folder naming `querio-samuele-units-<starting unit>-<ending unit>` when creating new folders; if a legacy folder already uses `querio-samuele-units-...`, preserve the existing naming in that path.
- In class folder ranges, allow `xx` for open-ended ranges when already used in the path (example: `querio-samuele-units-09-xx`).
- Unit and exercise folder names must use kebab-case and include the prefixed identifier (examples: `07-objects`, `08b-event-loop`, `02-oh-no-you-dont`).

- When creating an exercise folder, copy the structure and files from `js html css/template`, excluding the `template/other` subfolder.
- An `other` subfolder can exist in an exercise folder when needed; only the initial copy from template must exclude `template/other`.
- The exercise folder name must use kebab-case (example: `01-alien-frogs`).
- By default, each exercise folder should mirror `js html css/template` (excluding `other`), including `index.html`, `readme.md`, `assets/*`, `scripts/main.js`, and `styles/*`.
- Exception: if an exercise already provides its own files, or explicitly requires only a `.txt` or `.md` deliverable, keep that provided/minimal structure and do not force the full template copy.

### `index.html` Required Updates

- Update the `<title>` element to the exercise name (example: `1.Alien frogs`).
- Update the first `<h1>` element to the exercise name (example: `1.Alien frogs`) unless it has already been renamed from `REPLACE`.
- Update the `meta` description tag with an appropriate description for the specific exercise.
- Update the Open Graph section (`og:title`, `og:description`, `og:url`, and any other relevant OG fields) to match the exercise.
- The `og:url` value must follow the Live Server URL format for the exercise path (example: `http://127.0.0.1:5500/js%20html%20css/template/index.html`).

## readme.md Authoring Rules

When asked to produce or complete a `readme.md` for an exercise, follow the structure below:

```md
# [ExerciseNumber].[ExerciseName]
## Author
samuele.querio@edu-its.it

## Requirements
[paste the original exercise requirements verbatim]

## Approach to solution
[leave this section empty unless the user explicitly asks you to write it]
```

### Rules for each section

- **Title**: `# N.Exercise Name` — use the exercise number and human-readable name (e.g. `# 3.DOM Detective`).
- **Author**: always `samuele.querio@edu-its.it`.
- **Requirements**: copy the original exercise bullet points exactly, preserving nesting.
- **Approach to solution**: unless the user explicitly asks for a completed solution write-up, leave this section empty so it can be completed by the student.
