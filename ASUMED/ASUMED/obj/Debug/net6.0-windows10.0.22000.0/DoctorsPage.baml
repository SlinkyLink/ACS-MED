   M S B A M L   `   `   `  ����A  =ASUMED, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ASUMEDASUMED  5          ASUMED.DoctorsPage   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:ASUMED     5      -   5        $	��720��5      $
��1280��5	        N� Title$  Doctors��5
       � 	Resources 5       �� 
TargetType   
LeftBorder �� Property �� Value  	LeftLabel  
PhotoLabel  
LabelRight  TexBoxRight  ControlElipse  CtnMenuS  cmBorder  CtnMenuUpdate 	 cmBorderUpdate �� CornerRadius J� SnapsToDevicePixels �� Orientation
 � Tag��%�	  &	        &	 �     &	 �    &	 <    &	 �    &	 �    &	 �    &		 �    &	 "    7  7  &	 �    7  �� 5   
   " ��6   .�5      ��  � ��$ 4q�6(   �� 5       � ��
 ��  �6,   �� 5       � ��$ 25��6*   �� 5       �@��CornerRadius$ 10��6-   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 12(�6)   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�64   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 25(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Center=�64   5      �� 5   
   " ��6   .�5      ��  � ��$ 20(�6)   �� 5        � ��
 �����6+   �� 5!       � ��$
 Bold"�6+   �� 5"       � ��$ Right=�64   5#      �� 5$   
   " ��6   .�5%      ��  � ��$ 20(�6)   �� 5&       � ��$ 20��6*   �� 5'       � ��$ 0 4 0 4q�6'   �� 5(       �@��
IsReadOnly$
 True��6+   �� 5)       � ��$	 300��6)   5*      �� 5+   
   " A�6   .�5,      ��  � ��$ 35��6'   �� 5-       � ��$ 35��6&   �� 5.       � ��$ Center=�64   �� 5/       � ��$ 	15 0 15 0q�6'   �� 50       �@�Cursor$
 Hand��6'   51      �� 52   
   #���  6   
����  �6J   �� 53   
   #���  6   
����  �6U   �� 54   
   " ��6   .�55      ��  � �� 56      �� 57      .R�58      �� ���	#FF85BCD2$ 5��6:   $��2q�6K   
����  �$
 True��6q   ._�59      �� $ Vertical=�6)   .+�5:   "   �� -   5        $ DeleteB��5:   )   $	��150��67   $��0q�6F   
������ ���	#FF85BCD2._�5;   &   �� 8��  $��Delete��6O   $��Center=�6`   5<   #   �� 5=   "   ���	#FF85BCD2
������ $��1q�6[   �� 5>   "   -   5        $ UpdateB��5>   )   $	��150��67   $��0q�6F   ���	#FF85BCD2._�5?   &   �� 8�� $��Update��6O   $��Center=�6`   5@   #   5A      5B      5C      5E      5F      �� 5G   
   " ��6   .�5H      ��  � �� 5I      �� 5J      .R�5K      �� ���	#FF85BCD2$ 5��6:   $��2q�6K   
����  �$
 True��6q   ._�5L      �� $ Vertical=�6)   .+�5M   "   �� -   5        $ UpdateB��5M   )   $	��150��67   $��0q�6F   ���	#FF85BCD2._�5N   &   �� 8��  $��Update��6O   $��Center=�6`   5O   #   5P      5Q      5R      5T      5U      5V      .��5W      �� $ 15��6   ���	#FF29ABE2._�5X   
   � 	 � ColumnDefinitions	 5Y      �� 5Z      $��3* �6#   �� 5[      $��7* �6#   .+�5]      �� $ 15��6   $��0��6'   ���	#FFA0DFF8$��0 0 1 0q�6N   ._�5^      � 
 � RowDefinitions
 5_      �� 5`      $
��0.5* �6(   �� 5a      $
��9.5* �6(   .+�5c      �� -   5         ��Name$ LabelFSName��5c      $��Center=�61   $��Center=�6N   $��12(�6i   $
��Bold"�6w   
�������$��First Last NAME��6�   A� 5d      -   5         A�Name$ 	RefreshEl��5d   C    � Cursor$
 Hand��65   $��Right=�6V   $��Center=�6r   $��20��6�   $��0��6�   ��6�   ��  �� ElementName$ 	RefreshEl�� �� Path$ Height���5e      �� 5f       j� Stretch$ Uniform=�6)    �� ImageSource$ Sources/Refresh.png��6;   5h      �� 5i      $��1��6!   $ Vertical=�6.   $
��Auto=�6E   $
��True��6v   .+�5j      � -   5         �Name$ ScrollViewerList��5j      .+�5k      �� $
��Auto=�6+   .��5l   "   �� -   5         ��Name$ ListDoctorsPanel��5l   -   $ Vertical=�6G   .+�5m   &   �� #��[  6-   ._�5n   *   �� #��[ 60   $��	Exemple 1��6S   5o   '   �� 5p   &   #��[  6-   ._�5q   *   �� #��[ 60   $��	Exemple 2��6S   5r   '   �� 5s   &   #��[  6-   ._�5t   *   �� #��[ 60   $��	Exemple 3��6S   5u   '   5v   #   5w      5x      �� 5y      -	   5        $ AddBtn��5y   %   $ 
Horizontal=�65   $��Center=�6N   .+�5z      A� -
   5        #��[ 5z   '   $
 Hand��6b   ��5{   "   �� 5|   &   $ Uniform=�61   $ Sources/AddIcon.png��6C   5~      5�      5�      5�      5�      �� 5�      $ 15��6   $��1��6'   ���	#FFA0DFF8$��1q�6N   ._�5�      � 	 5�      �� 5�      $
��0.3* �6+   �� 5�      $��7.45* �6+   
 5�      �� 5�      $��1* �6(   �� 5�      $��9* �6(   .+�5�      � $��1��6   $��1��6+   $	��Top=�68   
 5�      �� 5�      $
��1.2* �6,   �� 5�      $	��267 �6,   �� 5�      $
��1.2* �6,   	 5�      �� 5�      $	��200 �6/   �� 5�      $
��1.5* �6/   �� 5�      $
��2.5* �6/   .+�5�      �� $��1��6!   $��0��6.   
�������$��2q�6R   ._�5�      �� $ Vertical=�6)   $��Center=�6@   $��Center=�6]   .+�5�   "   �� #��[ 6(   $��Фото��6L   �� 5�   "   #��[ 6(   $��Лікаря��6L   �� 5�   "   #��[ 6(   $	��3x4��6L   5�      5�      �� 5�      -   5        $ LablesVaribles��5�   B   $��1��6%   $��1��62   $ Vertical=�6Z   $��Right=�6q   $��Center=�6�   .+�5�      �� #��[ 6$   .��6H   ПІБ6M   �� 5�      #��[ 6$   .��6H   Дата реєстрації6Y   �� 5�      #��[ 6$   .��6H   !Хто зареєстрував6Z   �� 5�      #��[ 6$   .��6H   Номер паспорту6X   5�      �� 5�      -   5        $ TextBoxValues��5�   B   $��1��6%   $��2��62   $ Vertical=�6Y   $
��Left=�6p   $��Center=�6�   .+�5�      �� -   5         ��Name$ FLNameTextBox��5�   &   #��[ 6=   �� 5�      -   5        $ 	CreatedAt��5�   &   #��[ 69   �� 5�      -   5        $ 	CreatedBy��5�   &   #��[ 69   �� 5�      -   5        $ 
IDPassport��5�   &   #��[ 6:   5�      5�      5�      5�      5�      5�      5�      