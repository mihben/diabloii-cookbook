Feature: RU - Runes

    Rule: User needs to be authenticated

        Scenario: [INT-RU001][401-Unathorized] - Get runes without authentication
            When Call '/api/rune' GET endpoint without authentication
            Then Response with 403 - Unathorized
            
        Scenario: [INT-RU002][200-OK]: Get runes
            Given I have two runes
            When Call '/api/rune' GET endpoint without authentication
            Then Response with 200 - OK
            And I got two runes from the database