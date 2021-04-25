Feature: GC - Get character

    Rule: User needs to be authenticated

        Scenario: [INT-GC001][401-Unathorized] - Get characters without authentication
            When Call '/api/character' GET method
            Then Response with 403 - Unathorized

        Scenario: [INT-GC002][200-Ok] - Get characters
            Given I have two characters with 'integration-test' account
            When Call '/api/character' GET method
            Then Response with 200 - Ok
            And Ids of the characters

        Scenario: [INT-GC003][204-NoContent] - Get characters from unkown account
            When Call '/api/character' GET method
            Then Response with 204 - No Content

        Scenario: [INT-GC004][204-NoContent] - Account do not have character 
            Given I do not have character with 'integration-test' account
            When Call '/api/character' GET method
            Then Response with 204 - No Content

        Scenario: [INT-GC005][401-Unathorized] - Get characters without authentication
            Given I have character with <id> 'integration-test' account
            When Call '/api/character/<id>' GET method
            Then Response with 403 - Unathorized

        Scenario: [INT-GC006][200-Ok] - Get character detail without authentication
            Given I have character with <id> 'integration-test' account
            When Call '/api/character/<id>' GET method
            Then Response with 202 - Accepted
            And Detailed character