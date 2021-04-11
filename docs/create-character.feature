Feature: CC - Create character

    Scenario Outline: [UNT-VAL-CC001][Success] - Validate character
        Given Character with name, <Class>, IsLadder, IsExpansion
        When Create character
        Then Character should be valid
        Examples:
            | Class       |
            | Amazon      |
            | Assassin    |
            | Barbarian   |
            | Druid       |
            | Necromancer |
            | Sorceress   |
            | Paladin     |

    Scenario Outline: [UNT-VAL-CC002][Failure] - Missing name
        Given Character without <Name> name
        When Create character
        Then Character should be invalid
        Examples:
            | Name         |
            | <null>       |
            | <whitespace> |
            | <empty>      |

    Scenario Outline: [UNT-VAL-CC003][Failure] - Invalid level
        Given Character with <Level> level
        When Create character
        Then Character should be invalid
        Examples:
            | Level |
            | 0     |
            | 100   |

    Scenario Outline: [UNT-VAL-CC004][Failure] - Invalid class
        Given Character with <Class> class
        When Create character
        Then Character should be invalid
        Examples:
            | Class        |
            | <null>       |
            | <whitespace> |
            | <empty>      |
            | InvalidClass |

    Rule: User needs to be authenticated

        Scenario: [INT-CC001][401-Unathorized] - Create character without authentication
            When Call /api/character POST endpoint without authentication
            Then Response with 401 - Unathorized

        Scenario: [INT-CC002][202-Accepted] - Create account if not exists
            When Call /api/character POST endpoint with not existing account
            Then Response with 202 - Accepted
            And Account is created into the database

        Scenario: [INT-CC003][202-Accepted] - Create character
            When Call /api/character POST endpoint with not existing character
            Then Response with 202 - Accepted
            And Character is created into the database
            And Character added to the given account

        Scenario: [INT-CC004][202-Accepter] - Create existing character for different account
            Given Character is exists with name 'TestCharacter' and account 'TestAccount'
            When Call /api/character POST endpoint with Character with name 'TestCharacter' for 'integration_test' account
            Then Response with 202 - Accepted
            And Character is created into the database
            And Character added to the 'integration_test' account

        Scenario: [INT-CC005][400-Bad Request] - Create existing character
            Given Character is exists with name 'TestCharacter'
            When Call /api/character POST endpoint with Character with name 'TestCharacter'
            Then Response with 400 - Bad Request
            And Error code - 402
            And Message - 'TestCharacter has been already created'