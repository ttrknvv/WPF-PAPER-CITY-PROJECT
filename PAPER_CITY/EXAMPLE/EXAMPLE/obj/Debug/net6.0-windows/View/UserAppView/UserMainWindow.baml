   M S B A M L   `   `   `  ����D  @PaperCity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EXAMPLE.ViewEXAMPLE.View  5   	       EXAMPLE.View.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:EXAMPLE.View     5   	   -   5          �Name$  
windowMAIN��5   +      MainBackgroundUser#���   5   	    � Title$ 
MainWindow��5	   	   $	��650��5
   	   $	��820��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � Icon$  /View/UserAppView/icon.png��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��600 �6    � ColumnDefinitions 5   
   �� 5      $��90 �6   �� 5      $	��730 �6   .+�5   
   �� $��0��6   $��50��6    $��50��6+   $��0, 5, 20, 0q�67   $��0��5      $4��.D:\2k2s\COURSE_PROJECT\SOURCE\PHOTOES\icon.png��5      � 5   
   -   5        $��ToolBar��5      
������ $��0��5       $��1��6   .+�5"      �� -   5        $��PanelForMainElem��5"       �� Orientation$ 
Horizontal=�5#      $��Right=�5$      .+�5%      �� -   5        $��CollapseApp��5%      $��15��5&      $��15��5'      $��0, 0, 20, 0q�5(        MainElementsStyleCollapse#���  5)      	 J� Effect	 5+      -  'System.Windows.Media.Effects.BlurEffect  5,      
   Radius$	
 0.2Q�6%   5.      �� 5/      -   5        $��CloseApp��5/      $��15��50      $��15��51      $��5, 5 ,20, 5q�52        MainElementsStyleClose#���  53      	 55        56      $	
 0.2Q�6%   58      59      5:      �� 5=   
   $��0��6   $��1��6!   $��70��6.   $	��600��69   
������  �� CornerRadius$ 5��5>   *   $��0, 0, 24, 40q�5?      ._�5@      � .+�5A      �� -   5         ��Name$ listButtons��5A      $ Vertical=�5B      .+�5C      �� -   5        $��MainPageButt��5C        
ButtonMain#���  5D      ��5E      �� *OpenMainPage+��5F      ��  �� ElementName$ 
windowMAIN��.��5I      �� -   5         ��Name$ MainPage��5I       $:��4D:\2k2s\COURSE_PROJECT\SOURCE\PHOTOES\homeActive.png��5J        J� Opacity$ 1Q�5K       5L      �� 5M      -	   5         ��Name$ CatalogPageButt��5M        ButtonCatalog#���  5N      ��5O      �� *OpenCatalogPage+��5P      �� $ 
windowMAIN��.��5S      �� -
   5        $ CatalogPage��5S       $9��3D:\2k2s\COURSE_PROJECT\SOURCE\PHOTOES\open-book.png��5T       $	 0.3Q�5U       5W      �� 5X      -   5        $ BasketPageButt��5X        ButtonBusket#���  5Y      ��5Z      �� *OpenBasketPage+��5[      �� $ 
windowMAIN��.��5^      �� -   5        $ 
BasketPage��5^       $6��0D:\2k2s\COURSE_PROJECT\SOURCE\PHOTOES\basket.png��5_       $	 0.3Q�5`       5b      �� 5c      -   5        $ ProfilePageButt��5c        ButtonProfile#���  5d      ��5e      �� *OpenProfilePage+��5f      �� $ 
windowMAIN��.��5i      �� -   5        $ ProfilePage��5i       $7��1D:\2k2s\COURSE_PROJECT\SOURCE\PHOTOES\profile.png��5j       $	 0.3Q�5k       5m      �� 5n      -   5        $ HelpPageButt��5n        
ButtonHelp#���  5q      ��5o      �� *OpenHelpPage+��5p      �� $ 
windowMAIN��.��5t      �� -   5        $ HelpPage��5t       $8��2D:\2k2s\COURSE_PROJECT\SOURCE\PHOTOES\question.png��5u       $	 0.3Q�5v       5x      �� 5y      -   5         	 Leave#���  5y       	 ButtonLeave#��� 	 5z      5{      5|      5}      5~       � 5   
   -   5          �Name$ PageNow��5�      $|�False��5      $��1��5�      $��1��5�        � NavigationUIVisibility$ Hidden=�5�      ��5�      �� *
PageMain+5�      5�      5�      