   M S B A M L   `   `   `  ����  MathGame    MathGame.View.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Juego Matemático��5   	   $	��645��6"   $	��450��6/    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency$
 True��5   	    � 	Resources 5
         RoundedButton �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 �� Triggers P� Property P� Value��%>  &	        �� 5   
   " ��6&   .�5      ��  � �� �#4CAF506+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 15,10q�6(   �� 5       � ��$
 0,10q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $	 20��5   !   $��1q�5   !   ���#45a049._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      
 5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#45a04963   5       5"      5#      .��5%      �� ���#F0F0F0$	 10��6"   $��10q�64   ._�5&   
   �� $	 10��6   $��2q�6#    J� Opacity$
 0.95Q�67   ��5'      �� 5(       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5)      �  � Color$ #462AD8��6#    � Offset$ 0Q�63   � 5*      $ #DA34AE��6#   $
 0.75Q�63   � 5+      $ #8A16C1��6#   $ 1Q�63   5,      ._�5/      �  � RowDefinitions 50      �� 51      $��30 �6$   �� 52      $
��Auto �6$   �� 53      $��* �6$   �� 54      $
��Auto �6$   .+�57      � $��0��6    � ColumnDefinitions 58      �� 59      �� 5:      $��25 �6+   �� 5;      $��25 �6+   �� 5<      $��5 �6+   .+�5?      �� -   5         ��Name$ btnMinimize��5?      $��0q�5@      $��-��5A      
�������$��16(�5C      $��
Montserrat)�5D       � Cursor$
 Hand��5E      $��1��5F      ��5H      �� 5I      " ��6$   .�5J   "   ��  � �� �#28AEED6?   
 5K   "   P� 5L   &    �@J�IsMouseOver$
 True��6E   . �5M   *   ��  � �� �#278BEF6G   5N   '   5P      ��5R      �� 5S      " ��6.   .R�5T   "   �� $��18��6)   $��18��64   $	 9��5U      #��z��5V      ._�5W   &   �� $��Center=�67   $��Center=�5X   +   5Y   #   5Z      5\      �� 5]      -   5        $ btnClose��5]      $��0q�5^      $��X��5_      
�������$��12(�5a      $��
Montserrat)�5b      $
 Hand��5c      $��2��5d      ��5f      �� 5g      " ��6$   .�5h   "   ��  � �� �#DA34AE6?   
 5i   "   P� 5j   &    �@J�IsMouseOver$
 True��6E   . �5k   *   ��  � �� �#C62DAE6G   5l   '   5n      ��5p      �� 5q      " ��6.   .R�5r   "   �� $��18��6)   $��18��64   $	 9��5s      #��z��5t      ._�5u   &   �� $��Center=�67   $��Center=�5v   +   5w   #   5x      5z      5{      �� 5}      $��1��6   $��Juego Matemático��6)   $��32(�6A   $
��Bold"�6O   $��Center=�6a   $��	0,20,0,10q�6~   ���#3333336�   �� 5      $��2��6   $��20q�6*   .+�5�      �� -   5         ��Name$ DifficultyComboBox��5�       �� SelectedIndex$ 0��6;   $��0,0,0,10q�6M   $��16(�6_   .@�5�      �� $��Fácil��6'   �� 5�      $��Medio��6'   �� 5�      $��Difícil��6'   5�      �� 5�      -   5        $ StartButton��5�      $��Comenzar Juego��62   #��[  6K   �� 5�      
�������$	 10��60    �� Padding$ 20q�6B   $
��0,20q�6O   ._�5�      �� .+�5�      �� -   5         ��Name$ QuestionText��5�   (   $�� ��6>   $��24(�6F   $��Center=�6T   $��0,0,0,10q�6q   $
��Bold"�6�   � 5�      -   5         �Name$ TimeProgressBar��5�   *   $��10��6C    � Maximum$	 100Q�6O   $��0,0,0,10q�6]   �� 5�      -   5         ��Name$ 	AnswerBox��5�   &   $��20(�69   $��0,0,0,10q�6G   $��5q�6Y   6e   �� 5�      -	   5        $ CheckButton��5�   %   $��	Comprobar��6:   #��[  6N   5�      5�      �� 5�      -
   5        $ 
ResultText��5�       $��20(�64   $��Center=�6B   $
��0,10q�6_   $
��Bold"�6m   �� 5�      -   5        $ 	ScoreText��5�       $#��Puntuación: 0 | Preguntas: 0��63   $��18(�6W   $��Center=�6e   ���#6666666�   �� 5�      -   5        $ 
StreakText��5�       $��Racha: 0 | Mejor racha: 0��64   $��18(�6U   $��Center=�6c   ���#666666$��0,5,0,0q�6�   5�      �� 5�      -   5        $ EndGameButton��5�      $��Terminar Juego��60   #��[  6I   $��3��6p   $��
20,0,20,20q�6}   5�      5�      5�      5�      