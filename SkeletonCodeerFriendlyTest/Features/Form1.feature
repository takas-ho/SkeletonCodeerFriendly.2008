Feature: Form1の動作テスト

Scenario: 足し算
	Given 起動する
	When "TextBox1" に "12" を入力する
		And "TextBox2" に "34" を入力する
		And "+" ボタンを押す
	Then "TextBox3" は "46" になる

#Scenario: 引き算
#	Given 起動する
#	When 以下を入力する
#			|Name|Value|
#			|TextBox1|56|
#			|TextBox2|78|
#		And "-" ボタンを押す
#	Then "TextBox3" は "-22" になる
