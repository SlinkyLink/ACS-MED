   M S B A M L   `   `   `  ���� A  =ASUMED, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ASUMED.ControlASUMED.Control  "    ASUMED.Control.ClientExePage   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:ASUMED.Control     -   $	��350��$	��400��  N� Title$  ClientExePage�� � 	Resources  �� 
TargetType   VaribleLabel �� Property �� Value  ValueBorder  ValueTextBox  PreviewText  BtnC  ContexBorder  ContextScroll  ContextLabel��%q  &	        &	 l     &	     &	 �    &	 �    &	 �    &	 /    &	 �    �� " ��.���  � ��
 �   ���  � ��$ 15(���  � ��$
 Bold"���  � ��$ Right=��� " ��.���  � �� �	#FFB9EAFF��  �@��CornerRadius$ 7����  � ��$ 0 5 0 5q���  � ��$ 20����  � ��$ 20����  � ��$	 175���� " ��.���  � ��$	 175����  � ��
 ���� ��  � ��$ 0q���  � ��
 �   ���  � ��$ 15(���  � ��$ 
Myriad Pro)���  �@��TextAlignment$ Center=��� " ��.���  � ��$ 15(��� " ��.���  � ��$ Center=���  � ��$ Bottom=���  � �� �	#FFB9EAFF��  � ��$ 30����  � ��$	 100����  �@��CornerRadius$ 10����  �@�Cursor$
 Hand����  � ��$ 5q��� " ��.���  �@��CornerRadius$ 7����  � �� �	#FFB9EAFF�� " ��.���  � ��$	 200����  � ��$	 350����  � ��$
 Auto=���  � ��$
 Auto=��� " ��.���  � ��
 �   ���  � ��$ 12(���  � ��$ Center=���  � ��$ Center=���  � ��$
 Bold"�.���  � RowDefinitions �� $��7* ��� $��2* �.+�� $��0��.+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� -    ��Name$ LabelVaribles��$��0��$ Vertical=�$	��Top=�$��Center=�.+��� #��[  $��ПІБ���� #��[  $��Вага���� #��[  $��
Зріст���� #��[  $!��Номер телефону���� -   $ AddLabelVaribles��$ Vertical=�.+��� #��[  $��
Стать���� #��[  $#��Дата народження���� #��[  $��Група крові���� -   $ TextBoxValues��$��1��$ Vertical=�$	��Top=�$��Center=�.+��� #��[ ._��� -    ��Name$ TextBoxFLName��#��[ �� #��[ ._��� -   $ TextBoxWeightValue��#��[ �� #��[ ._��� -   $ TextBoxGrowthValue��#��[ �� #��[ ._��� -   $ TextBoxNumberValue��#��[ �� -	   $ AddTexBoxValues��$ Vertical=�.+��� -
   $��	BorderSex��#��[ ._��� -   $ TextBoxSexValue��#��[ 	 �� 
IsReadOnly$
	 True��$|�False��
 � Cursor$
 Arrow���� #��[ ._��� -   $ TextBoxDateBirthValue��#��[ �� -   #��[ ._��� -   $ TextBoxRhFactorValue��#��[ $
	 True��$|�False��$
 Arrow��� -    �Name$ 	ContexSex��$	��100��$��140.5 190 0 0q�$y�Hidden=�����  �� Path$ ActualWidth� �� ElementName$ 	BorderSex��.+��� #��[ $��1q�
����  �����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF2AABE2��� $ 	#FF84DBFF�� � Offset$ 1Q�._�� .+��� -   $ StackPanelSexValues��$ Vertical=�� -   $ ContexRhFactor��$	��150��$��140.5 0 0 0q�$y�Hidden=����� $ ActualWidth�$ 	BorderSex��.+��� #��[ $��1q�
����  ����� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF2AABE2��� $ 	#FF84DBFF��$ 1Q�._�� .+��� $
��Auto=�.���� -   $ StackPanelRhFactorValues��$ Vertical=��� $��1��$��2��$ 
Horizontal=�$	��Top=�$��Center=�.+��� -    ��Name$ 	BorderExe��#��[ ._��� $��Center=�$��15(�
���   ��� -   #��[ ._��� $��Center=�$��15(�
���   �.��Відмова