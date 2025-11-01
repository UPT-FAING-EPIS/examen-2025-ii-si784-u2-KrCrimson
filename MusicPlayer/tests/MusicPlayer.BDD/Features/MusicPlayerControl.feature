Feature: Music Player Control
    As a music listener
    I want to control music playback
    So that I can play, pause, and skip songs

Scenario: Play a song
    Given I have a music player
    And I have a remote control
    When I set the play command
    And I press the button
    Then the result should be "Playing the song."

Scenario: Pause a song
    Given I have a music player
    And I have a remote control
    When I set the pause command
    And I press the button
    Then the result should be "Pausing the song."

Scenario: Skip to next song
    Given I have a music player
    And I have a remote control
    When I set the skip command
    And I press the button
    Then the result should be "Skipping to the next song."

Scenario: Press button without setting command
    Given I have a remote control
    When I press the button without setting a command
    Then the result should be "No command set."

Scenario: Change commands dynamically
    Given I have a music player
    And I have a remote control
    When I set the play command
    And I press the button
    And I set the pause command
    And I press the button again
    Then the first result should be "Playing the song."
    And the second result should be "Pausing the song."
