   M S B A M L   `   `   `  ����D  @PaperCity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EXAMPLE.ViewEXAMPLE.View  5   	   !    EXAMPLE.View.FormForBuyBook   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:EXAMPLE.View     5   	     � Title$  FormForBuyBook��5   	   ���	#FFB8CEE7$	��380��5
   	   $	��400��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$+ %/View/UserAppView/addBookUnactive.png��6.   .��5      � .+�5   
   �� .+�5      �� -   5        $��
NumberPlug��5         
NumberCard#���   5      
���   �$
��Left=�5      $��20(�5      $��50, 10, 0, 0q�5      $	��160��5       K� ZIndex$	 999��5       J� IsHitTestVisible$ False��5      �� 5      -   5        $��
NumberCard��5      $	��Top=�5      $��
0, 6, 0, 0q�5        
ForBuyBook#���  5      $��Center=�5      �� 5      -   5        $��DatePlug��5        DateCard#���  5      
���   �$
��Left=�5!      $��20(�5"      $��50, 6, 0, 0q�5#      $	��160��5$      $	 999��5%      $ False��5&      �� 5'      -   5        $
��Date��5'      $	��Top=�5(      $��
0, 6, 0, 0q�5)      #���  5*      $��Center=�5+      �� 5,      -   5        $��NamePlug��5,        NameOwnerCard#���  5-      
���   �$
��Left=�5/      $��20(�50      $��50, 6, 0, 0q�51      $	��170��52      $	 999��53      $ False��54      �� 55      -   5        $��	NameOwner��55      $	��Top=�56      $��
0, 6, 0, 0q�57      #���  58      $��Center=�59      � 5:       � Orientation$ 
Horizontal=�6   $��Center=�5;      $��0, 14, 0, 0q�5<      $��40��5=      .+�5>      �� -   5        $��Ok��5>        BuyBook#���  5?        	ButtonBuy#���  5@      5A      �� 5C      -   5        $��NotOk��5C       
 Cansel#���  5D      #���  5E      $��40, 0, 0, 0q�5F      5G      5H      5I      5M      5N      