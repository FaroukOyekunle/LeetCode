✅ Explanation

Pattern Definitions
Pattern Type	Description	SQL Implementation
has_start	Starts with "ATG"	dna_sequence LIKE 'ATG%'
has_stop	Ends with "TAA", "TAG", or "TGA"	`dna_sequence REGEXP '(TAA
has_atat	Contains "ATAT" anywhere	dna_sequence LIKE '%ATAT%'
has_ggg	Contains at least 3 consecutive G (GGG, GGGG, etc.)	dna_sequence LIKE '%GGG%'