Feature: STF - Store filters

    Scenario: [INT-STF001][401-Unathorized]: Save filters without authorization
    When I call '/api/filter' POST endpoint
    Then Response with 401 - Unathorized

    Scenario: [INT-STF002][202-Accepted]: Save item type filter
    Given I have a charachter with <characterId> id
    When I call '/api/filter' POST endpoint with <itemTypeId>
    Then Response with 202 - Accepted
    And <itemTypeId> should be saved into the database for <characterId> as filter

    Scenario: [INT-STF003][400-BadRequest]: Save filter for not existing character
    When I call '/api/filter' POST endpoint with <itemTypeId>
    Then Response with 400 - BadRequest