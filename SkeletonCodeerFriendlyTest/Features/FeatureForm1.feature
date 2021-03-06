﻿Feature: Form1の動作テスト

Scenario: 足し算
	Given 起動する
	When TextBox "TextBox1" に "12" を入力する
		And TextBox "TextBox2" に "34" を入力する
		And Button "+" を押す
	Then TextBox "TextBox3" は "46" になる

Scenario: 引き算（ディビジョンテーブルで）
	Given 起動する
	When 以下を入力する
			| Type    | Name     | Value |
			| TextBox | TextBox1 | 56    |
			| TextBox | TextBox2 | 78    |
		And Button "-" を押す
	Then TextBox "TextBox3" は "-22" になる
