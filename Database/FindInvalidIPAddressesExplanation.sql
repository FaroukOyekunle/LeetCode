✅ Explanation

I classify invalid IP addresses based on three key rules:

    1.  Not Exactly 4 Octets:

        *   An IPv4 must have 3 dots (4 octets).

        *   Check using:

        LENGTH(ip) - LENGTH(REPLACE(ip, '.', '')) != 3

    2.  Leading Zeros:

    *   I use regex to match any octet with leading zeros:

        REGEXP_LIKE(ip, '\\b0[0-9]+\\b')

    3.  Octet > 255:

    *   Then i extract the four octets using:

        SUBSTRING_INDEX(SUBSTRING_INDEX(ip, '.', N), '.', -1)

Then cast and check if any octet is greater than 255.