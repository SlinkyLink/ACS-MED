   M S B A M L   `   `   `  ����A  =ASUMED, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ASUMEDASUMED  5          ASUMED.AboutPage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:ASUMED     5      -   5        $	��720��5      $
��1280��5	        N� Title$  	AboutPage��5
       � 	Resources 5       �� 
TargetType   
LeftBorder �� Property �� Value  	LeftLabel��%�  &	        &	 �     �� 5   
   " ��6   .�5      ��  � ��$ 4q�6(   �� 5       � ��
 ��  �6,   �� 5       � ��$ 25��6*   �� 5       �@��CornerRadius$ 10��6-   �� 5       �@�Cursor$
 Hand��6'   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 12(�6)   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�64   �� 5       � ��$
 Bold"�6+   5      5      .��5      ��  �� CornerRadius$ 15��6   ���	#FF29ABE2._�5   
   �  � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��7* �6#   .+�5!      �� $ 15��6   $��0��6'   ���	#FFA0DFF8$��0 0 1 0q�6N   ._�5"      �  � RowDefinitions 5#      �� 5$      $
��0.5* �6(   �� 5%      $
��9.5* �6(   .+�5'      �� -   5         ��Name$ LabelFSName��5'      $��Center=�61   $��Center=�6N   $��12(�6i   $
��Bold"�6w   
�������$��First Last NAME��6�   �� 5(      $��1��6!   	 �� Orientation$	 Vertical=�6.   .+�5)      �� -   5        
 ��Name$
 ListDoctorsPanel��5)   %   $	 Vertical=�6?   .+�5*      �� -   5        #��[  5*   %   
 � Tag$ gf��6I   ._�5+   "   �� #��[ 6(   $��Ліцензія��6K   5,      �� 5-      -   5        #��[  5-   %   $  ��6I    � Cursor$
 Hand��6q   ._�5.   "   �� #��[ 6(   $��Розробники��6K   5/      50      51      52      53      �� 54      -   5         ��Name$ BorderContent��54      $ 15��6,   $��1��6>   ���	#FFA0DFF8$��1 0 0 0q�6e   ._�55      �  56      �� 57      $��75 �6(   �� 58      .+�5:      �� -   5        $ LabelPageInfo��5:   )   $��0��6   $��Center=�6@   $��Bottom=�6]   $��20(�6x   $��
Myriad Pro)�6�   
�������6�   �� 5;      -   5         ��Name$ TextBoxContent��5;   +   $��1��6   $��25q�6C    �� 
IsReadOnly$
 True��6O    �� TextAlignment$ Center=�5<   !   $
��Auto=�5=   !   $
��Auto=�5>   !   $
��True��5?   !    �� TextWrapping$
 Wrap=�5@   !    �� AcceptsReturn$
 True��65   .��6J   5A      5B      5C      5D      5E      5F      