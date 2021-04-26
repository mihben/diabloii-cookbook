Feature: UC - Update character

    Scenario: [UNT-VAL-UC001][Success] - Validate character
        Given Character with valid an id and <level>
        When Create character
        Then Character should be valid
        Examples:
            | Level |
            | 1     |
            | 99    |
            | 50    |

    Scenario Outline: [UNT-VAL-UC002][Failure] - Empty id
        Given Character with <Id>
        When Create character
        Then Character should be invalid
        Examples:
            | Id                                     |
            | {00000000-0000-0000-0000-000000000000} |

    Scenario Outline: [UNT-VAL-UC003][Failure] - Invalid level
        Given Character with <Level>
        When Create character
        Then Character should be invalid
        Examples:
            | Level |
            | 0     |
            | 100   |

    Rule: User needs to be authenticated

        Scenario: [INT-UC001][401-Unathorized] - Update character without authentication
            When Call /api/character/{id} PUT endpoint without authentication
            Then Response with 403 - Unathorized

        Scenario Outline: [INT-UC002][400-BadRequest] - Update not existed character
            Given Character not exists with <Id>
            When Call /api/character/<Id> PUT endpoint
            Then Response with 400 - Bad Request
            And Error code - 204
            And Error message - 'Character does not exists'
            Examples:
                | Id                                     |
                | {A540722D-B676-4534-AF17-055C40D8C912} |

        Scenario Outline: [INT-UC003][202-Accepted] - Update character level
            Given Character not exists with <Id> with <Level>
            When Call /api/character/<Id> PUT endpoint with <NewLevel>
            Then Response with 202 - Accepted
            And Level update to <NewLevel>
            Examples:
                | Id                                     | Level | NewLevel |
                | {31BC0B16-D36B-4AA6-B317-2D36077775BF} | 1     | 2        |

        Scenario Outline: [INT-UC004][202-Accepted] - Update character runes
            Given Character not exists with <Id> with <Runes>
            When Call /api/character/<Id> PUT endpoint with <NewRunes>
            Then Response with 202 - Accepted
            And <NewRunes> updated
            Examples:
                | Id                                     | Runes   | NewRunes |
                | {31BC0B16-D36B-4AA6-B317-2D36077775BF} | <empty> | El       |