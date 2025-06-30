✅ Explanation

-   split_words CTE – Break sentence into individual words

-   I uses a recursive CTE to extract one word at a time from each content_text.

-   SUBSTRING_INDEX(..., ' ', 1) gets the first word.

-   SUBSTRING(..., LENGTH(...) + 2) trims the rest of the sentence after the first word.

-   Repeats this until all words are extracted.

-   Tracks the position of each word (word_pos) for later reordering.

----------------------------------------

-   processed_words CTE – Format each word properly

-   I applies a CASE statement to check if the word contains a hyphen:

    -   If hyphenated:

        -   I splits the word into two parts using SUBSTRING_INDEX.

        -   I capitalizes the first letter of each part with UPPER(...) and makes the rest lowercase with LOWER(...).

        -   Rejoins both parts with a hyphen.

    -   If not hyphenated:

        -   I capitalizes the first letter using UPPER(LEFT(...)) and lowercases the rest using LOWER(...).

-----------------------------------------------

-   reconstructed CTE – Rebuild the full sentence

-   I groups all processed words by content_id and original content_text.

-   Then i uses GROUP_CONCAT to join the words back together with a space separator.

-   Also uses ORDER BY word_pos to maintain the original word order.

--------------------------------------------------

-   Final SELECT – Display result
-   Returns three columns:

    -   content_id

    -   original_text (unchanged)

    -   converted_text (formatted string with proper capitalization)