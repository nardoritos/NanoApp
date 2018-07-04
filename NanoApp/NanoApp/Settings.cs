using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NanoApp
{
    class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }
        public static string Senha
        {
            get => AppSettings.GetValueOrDefault(nameof(Senha), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Senha), value);
        }
        public static string Cargo
        {
            get => AppSettings.GetValueOrDefault(nameof(Cargo), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Cargo), value);
        }
        public static string Obra
        {
            get => AppSettings.GetValueOrDefault(nameof(Obra), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Obra), value);
        }
        public static string Motorista
        {
            get => AppSettings.GetValueOrDefault(nameof(Motorista), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Motorista), value);
        }
        public static string Tipo
        {
            get => AppSettings.GetValueOrDefault(nameof(Tipo), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Tipo), value);
        }
    }
}
