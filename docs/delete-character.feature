Feature: DC - Delete character

    Rule: User needs to be authenticated

        Scenario: [INT-DC001][401-Unathorized] - Delete character without authentication
            When Call /api/character/{id} DELETE endpoint without authentication
            Then Response with 403 - Unathorized

        Scenario Outline: [INT-DC002][400-BadRequest] - Delete not existed character
            Given Character not exists with <Id>
            When Call /api/character/<Id> DELETE endpoint
            Then Response with 400 - Bad Request
            And Error code - 204
            And Error message - 'Character does not exists'
            Examples:
                | Id                                     |
                | {A540722D-B676-4534-AF17-055C40D8C912} |

        Scenario Outline: [INT-DC003][400-BadRequest] - Delete other account's character
            Given Character exists with <Id> and <Account> account
            When Call /api/character/<Id> DELETE endpoint with <NewAccount>
            Then Response with 400 - Bad Request
            And Error code - 204
            And Error message - 'Character does not exists'
            Examples:
                | Id                                     | Account     | NewAccount       |
                | {A540722D-B676-4534-AF17-055C40D8C912} | TestAccount | integration_test |

        Scenario Outline: [INT-DC004][202-Accepted] - Delete character level
            Given Character not exists with <Id>
            When Call /api/character/<Id> DELETE endpoint
            Then Response with 202 - Accepted
            And Level update to <NewLevel>
            Examples:
                | Id                                     |
                | {31BC0B16-D36B-4AA6-B317-2D36077775BF} |