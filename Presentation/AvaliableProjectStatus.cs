﻿using System.Collections.Generic;

namespace Presentation {
    public static class AvaliableProjectStatus {
        private static readonly List<string> projectStatusCollection;
        static AvaliableProjectStatus() {
            projectStatusCollection = new List<string> {
                "Первичный контакт",
                "Переговоры",
                "Согласование договора",
                "В работе",
                "Закончен"
            };
        }
        public static List<string> GetAvaliableStatusList() {
            return projectStatusCollection;
        }
    }
}