   M S B A M L   `   `   `  ����A  =Tester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TesterTester  5   	       Tester.testPassing   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Tester     5   	     � Title$  testPassing��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��QuestionTextBlock��5   M   $��0��6   $��10q�6!   $��20(�6-   $
��Bold"�6;   $��Вопрос:��6f   �� 5   
   -   5        $��ChoicesListView��5   E   $��1��6   $��10q�6     �� SelectionMode$ Multiple=�6,    �� View 5      �� 5      .P�5      �� $#��Варианты ответа��6%    �� Width$	 450��6>   5      5      �� 5   
   -   5        $��2��5      $��10q�6   $%��Следующий вопрос��6*   6E   �� 5   
   -   5        $��ResultTextBlock��5   M   $��3��6   $��10q�6!   $��16(�6-   $
��Bold"�6;   $��Результат:��6d   5      5      