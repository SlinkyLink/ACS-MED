   M S B A M L   `   `   `  ����A  =ASUMED, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ASUMED.ControlASUMED.Control  5   	       ASUMED.Control.DBControl   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ASUMED.Control     5   	   -   5          � Title$  	DBControl��5   	    � WindowStyle$
 None=�5	   	   $	��350��5
   	   $	��400��6    � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � 
ResizeMode$ NoResize=�5   	    � 	Resources 5       �� 
TargetType   VaribleLabel �� Property �� Value  ValueBorder  ValueTextBox  BtnC��%Q  &	        &	 �     &	 �    &	 �    �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 15(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Right=�64   5      �� 5   
   " ��6   .�5      ��  � �� �	#FFB9EAFF6+   �� 5       �@��CornerRadius$ 7��6-   �� 5       � ��$ 0 5 0 5q�6'   �� 5       � ��$ 20��6*   �� 5       � ��$ 20��6*   �� 5       � ��$	 175��6)   5      �� 5    
   " ��6   .�5!      ��  � ��$	 175��6&   �� 5"       � ��
 ���� 6+   �� 5#       � ��$ 0q�60   �� 5$       � ��
 �   �6+   �� 5%       �@��TextAlignment$ Center=�6.   5&      �� 5'   
   " ��6   .�5(      ��  � ��$ Center=�64   �� 5)       � ��$ Bottom=�62   �� 5*       � �� �	#FFB9EAFF6+   �� 5+       � ��$ 30��6*   �� 5,       � ��$	 100��6)   �� 5-       �@��CornerRadius$ 10��6-   �� 5.       �@�Cursor$
 Hand��6'   �� 5/       � ��$ 5q�6'   50      51      .��52      �� 	 �� CornerRadius$	 15��6   ��53   
   �� 54      
 �� EndPoint$
 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��55      �  � Color$ 	#FF29ABE2��6   � 56      $ 	#FF85DBFF��6    � Offset$ 1Q�61   57      ._�59   
   �  � RowDefinitions 5:      �� 5;      $
��0.5* �6    �� 5<      $��8* �6    .+�5>      � -   5         �Name$ TitleBar��5>      
������ $��0��6>   $��28��6K   $	��Top=�6W   5@      � 5A      -   5        $ ElementsGrid��5A       $��2��6   .+�5B       � -   5          �Name$ WindowContent��5B        � NavigationUIVisibility$ Hidden=�6/   5C      5D      5E      5F      