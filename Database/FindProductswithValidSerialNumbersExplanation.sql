✅ Explanation

I split the logic into two cases:

1.  Pattern at the start of the string:


^SN[0-9]{4}-[0-9]{4}([^0-9]|$)

    -   Must start with SNxxxx-yyyy and either end there or be followed by a non-digit.

2.  Pattern inside the string:

[^A-Za-z0-9]SN[0-9]{4}-[0-9]{4}([^0-9]|$)

    -   I ensures it is not part of a longer word ([^A-Za-z0-9] and it is preceded by a non-alphanumeric character).

    -   Then i also prevents matches like ASN4321-8765.