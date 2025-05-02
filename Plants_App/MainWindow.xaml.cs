using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Plants_App {
    /*-- 1. Сначала добавляем столбец с возможностью NULL значений
ALTER TABLE Partners ADD discount DECIMAL(5,2) NULL;

-- 2. Создаем временную таблицу или CTE с вычисленными скидками
WITH PartnerDiscounts AS(
    SELECT
        pp.Partner_name,
        CASE
            WHEN SUM(pp.Product_count* Products.Minimum_coast_for_partner) < 10000 THEN 0
            WHEN SUM(pp.Product_count* Products.Minimum_coast_for_partner) BETWEEN 10000 AND 50000 THEN 5
            WHEN SUM(pp.Product_count* Products.Minimum_coast_for_partner) BETWEEN 50000 AND 300000 THEN 10
            WHEN SUM(pp.Product_count* Products.Minimum_coast_for_partner) > 300000 THEN 15
        END AS calculated_discount
    FROM
        Partner_products pp
        INNER JOIN Products ON pp.Product = Products.Product_name
    GROUP BY
        pp.Partner_name
)

-- 3. Обновляем таблицу Partners на основе вычисленных скидок
UPDATE Partners
SET discount = pd.calculated_discount
FROM Partners p
INNER JOIN PartnerDiscounts pd ON p.Partner_name = pd.Partner_name;

-- 4. Теперь можно изменить столбец на NOT NULL(если все значения заполнены)
ALTER TABLE Partners ALTER COLUMN discount DECIMAL(5,2) NOT NULL;*/
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            using (var context = new PlantsBdContext()) {
                receiptsItemsControl.ItemsSource = context
                .Partners
                .ToList();
            }
        }

        private void StackPanelMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            var partner = (sender as StackPanel).DataContext as Partner;
            var newWindow = new EditWindow(partner);

            // Открываем окно как модальное (блокирующее)
            newWindow.ShowDialog();
        }
    }
}