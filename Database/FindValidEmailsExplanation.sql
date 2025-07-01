✅ Explanation

We need to validate email addresses based on the following criteria:

1.  Exactly one '@' → handled by a well-crafted regex.

2.  Ends with .com → use \\.com$ (escaped dot and end of string).

3.  Before the '@': must be alphanumeric or underscore → [a-zA-Z0-9_]+

4.  Domain (after '@' and before .com): letters only → [a-zA-Z]+

-------------------------------------------------

Putting it all together:

-   ^[a-zA-Z0-9_]+ → local part before @

-   @ → the separator

-   [a-zA-Z]+ → valid domain name (only letters)

-   \\.com$ → must end in .com

So, the regex is:
'^[a-zA-Z0-9_]+@[a-zA-Z]+\\.com$'