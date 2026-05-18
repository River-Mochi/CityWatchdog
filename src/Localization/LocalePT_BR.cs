// File: src/Localization/LocalePT_BR.cs
// Purpose: Brazilian Portuguese (pt-BR) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocalePT_BR(Setting setting)
        {
            m_Settings = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ModName;
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title += " (" + Mod.ModVersion + ")";
            }

            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                // --- Mod title ---
                { m_Settings.GetSettingsLocaleID(), title },

                // --- Tabs ---
                { m_Settings.GetOptionTabLocaleID(Setting.Actions), "Ações" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Atalhos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Sobre" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Depuração" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "Conquistas" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Marco" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Converter save" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Atalhos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },

                // --- Achievements ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "Ativar conquistas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)),
                    "Mantém conquistas ativadas [ ✓ ] enquanto este mod estiver carregado.\n" +
                    "É recomendado usar o mod <Achievement Fixer (AF)>, pois ele é mais completo e robusto nessa área.\n" +
                    "Se <Achievement Fixer> estiver instalado, o City Watchdog esconde esta opção e deixa o AF cuidar das conquistas.\n" +
                    "FUTURO: pretendo mesclar o AF neste mod; por enquanto, adicionar o AF é a melhor opção." },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendTracker)), "Rastreador de tendências" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendTracker)),
                    "Adiciona valores numéricos ao lado das setas de tendência de dinheiro e população na barra inferior.\n" +
                    "É apenas uma leitura visual leve; não altera dinheiro nem população." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendDisplayMode)), "Modo de exibição de tendência" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendDisplayMode)),
                    "Escolha se o texto de tendência da barra inferior mostra valores por hora ou mensais.\n" +
                    "Mensal usa receita menos despesa para dinheiro e uma projeção de 24 horas para população." },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeMonthly"), "Por mês (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Valor do atalho de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Use este valor com os atalhos de Adicionar dinheiro e Subtrair dinheiro.\n" +
                    "Padrão = 20.000.\n" +
                    "Isto não altera o saldo atual sozinho." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Adicionar dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quando ativado [ ✓ ], o City Watchdog verifica o saldo da cidade enquanto ela está carregada.\n" +
                    "Se o saldo estiver abaixo do limite, ele adiciona o valor automático escolhido." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Limite do dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se Adicionar dinheiro automático estiver ativado e o saldo da cidade cair abaixo deste valor,\n" +
                    "o City Watchdog adiciona o valor automático escolhido." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Valor automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Valor adicionado cada vez que o dinheiro automático é acionado.\n" +
                    "Escolha um valor alto o bastante para deixar a cidade acima do limite com segurança." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinheiro inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Define o saldo inicial para uma nova cidade com <dinheiro limitado> ou para a primeira cidade carregada, depois volta para o padrão do jogo.\n" +
                    "Fica cinza se uma cidade já estiver carregada.\n" +
                    "Defina antes de iniciar/carregar uma cidade → aplica uma vez → depois use <Valor do atalho de dinheiro> ou <Adicionar dinheiro automático>." },
                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Seletor de marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Ative antes de carregar ou iniciar uma cidade para desbloquear o marco escolhido logo após a cidade carregar.\n" +
                    "Não pode ser ligado enquanto uma cidade já está carregada, mas pode ser desligado se ficou ligado por engano.\n" +
                    "O City Watchdog não desfaz mudanças de marco já salvas na cidade; use um save anterior se necessário." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Escolha o nível de marco para desbloquear no próximo carregamento da cidade.\n" +
                    "Só pode ser ajustado fora de uma cidade carregada e apenas depois que [Seletor de marco] estiver ativado [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faça backup da cidade PRIMEIRO>.\n" +
                    "Converte uma cidade criada com Dinheiro ilimitado em uma cidade normal com desafios de dinheiro.\n" +
                    "Ativar isto libera o botão <[Converter save de dinheiro ilimitado]> quando a cidade carregada for do tipo <Dinheiro ilimitado>.\n" +
                    "O City Watchdog não pode desfazer esta conversão.\n" +
                    "Se suas cidades são normais, não se preocupe; isto não é necessário." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converter cidade de dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Para cidades iniciadas com <Dinheiro ilimitado>.\n" +
                    "Enquanto essa cidade está carregada, converte o save para orçamento normal com dinheiro limitado, trazendo de volta o desafio de dinheiro.\n" +
                    "O botão fica <desativado/cinza> a menos que a cidade carregada seja do tipo <Dinheiro ilimitado> e <Conversor de dinheiro ilimitado> esteja ON [ ✓ ].\n" +
                    "Faça backup e use por sua conta e risco; o City Watchdog não pode desfazer esta conversão." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\n" +
                    "Salve um backup PRIMEIRO; o City Watchdog não pode desfazer isto.\n" +
                    "Tem certeza?" },

                // --- Hotkeys ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar ícones de notificação" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "Atalho para a mesma ação do botão [Alternar tudo] no painel do jogo.\n" +
                    "Mostra ou oculta todos os ícones de notificação do City Watchdog de uma vez." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Alternar ícones de notificação" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atalho para adicionar dinheiro dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Adicionar dinheiro" },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atalho para subtrair dinheiro dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtrair dinheiro" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome do mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome exibido deste mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versão" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versão atual do mod." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abre a página do autor no Paradox Mods." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instruções" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostra ou oculta as instruções abaixo." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Painel de notificações>\n" +
                    "1. No jogo, clique no botão City Watchdog no canto superior esquerdo para abrir o painel.\n" +
                    "2. Use ASC/DESC para ordenar as seções.\n" +
                    "3. Use Alternar tudo para configuração rápida, ou expanda uma seção para mudar ícones individuais.\n" +
                    "4. O City Watchdog só oculta ou mostra ícones; ele não corrige o problema da cidade.\n" +
                    "\n" +
                    "<Ferramentas de dinheiro>\n" +
                    "1. Rastreador de tendências adiciona valores /h ou /mo ao lado das setas de dinheiro e população.\n" +
                    "2. Adicionar dinheiro e Subtrair dinheiro usam o Valor do atalho de dinheiro.\n" +
                    "3. Adicionar dinheiro automático observa o saldo da cidade enquanto ela está carregada e adiciona dinheiro abaixo do limite.\n" +
                    "4. Converter save de Dinheiro ilimitado é apenas para cidades iniciadas com Dinheiro ilimitado e <não pode ser revertido> pelo City Watchdog.\n" +
                    "\n" +
                    "<Marco personalizado>\n" +
                    "Defina Dinheiro inicial e selecione Marcos no menu de Opções antes de carregar ou iniciar uma cidade." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification SIP panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Abrir o painel de ícones de notificação." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Expanda qualquer seção; marque [✓] para mostrar e desmarque para ocultar alertas.\n" +
                    "Isto não corrige problemas da cidade; apenas reduz a poluição visual dos ícones." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Alternar tudo" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Expandir tudo" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Recolher tudo" },
                { m_Settings.GetUILocaleID("SortAscending"), "ASC ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "DESC ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "Ordem de classificação" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"), "Mostrar ou ocultar todos os ícones" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "ELETRICIDADE" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Energia insuficiente" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Gargalo elétrico" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Fluxo elétrico ruim" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Usina sobrecarregada" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Transformador sobrecarregado" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "Linhas de saída conectadas insuficientes" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Bateria descarregada" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Cabo elétrico desconectado" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Linha de energia desconectada" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "ÁGUA / ESGOTO" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "Água insuficiente" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Bomba de água poluída" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Esgoto acumulado" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Cano de água desconectado" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Cano de esgoto desconectado" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Instalação de água sobrecarregada" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Instalação de esgoto sobrecarregada" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Nível de água subterrânea muito baixo" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Nível de água muito baixo" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Bomba de água poluída" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "CONSTRUÇÃO" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Desabou" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Abandonado" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Condenado" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Desativado" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "Aluguel alto" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "TRÁFEGO" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Congestionamento" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Rua sem saída" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Precisa de estrada" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Trilho desconectado" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "Sem acesso de carro" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Sem conexão aquaviária" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Sem conexão ferroviária" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "Sem acesso de pedestres" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "EMPRESA" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "Custos de recursos altos" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "Clientes insuficientes" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "EMPREGOS" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Falta de mão de obra" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Falta de mão de obra qualificada" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "DESASTRE" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Dano climático" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Destruído pelo clima" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Dano por água" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Destruído por inundação" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Este prédio foi destruído" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "INCÊNDIO" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "Pegando fogo" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Queimou completamente" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "LIXO" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Lixo acumulando" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Instalação cheia" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "SAÚDE" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "Aguardando ambulância" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "Aguardando carro funerário" },
                { m_Settings.GetUILocaleID("HealthcareFacilityFullNotification"), "Instalação cheia" },

                // --- Police notifications ---
                { m_Settings.GetUILocaleID("Police"), "POLÍCIA" },
                { m_Settings.GetUILocaleID("PoliceTrafficAccidentNotification"), "Acidente de trânsito" },
                { m_Settings.GetUILocaleID("PoliceCrimeSceneNotification"), "Cena de crime" },

                // --- Pollution notifications ---
                { m_Settings.GetUILocaleID("Pollution"), "POLUIÇÃO" },
                { m_Settings.GetUILocaleID("PollutionAirPollutionNotification"), "Poluição do ar" },
                { m_Settings.GetUILocaleID("PollutionNoisePollutionNotification"), "Poluição sonora" },
                { m_Settings.GetUILocaleID("PollutionGroundPollutionNotification"), "Poluição do solo" },

                // --- Resource and route notifications ---
                { m_Settings.GetUILocaleID("ResourceConsumer"), "CONSUMIDOR DE RECURSOS" },
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Sem suprimentos de abrigo de emergência" },
                { m_Settings.GetUILocaleID("Route"), "ROTA" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Falha ao encontrar caminho" },

                // --- Transport line notifications ---
                { m_Settings.GetUILocaleID("TransportLine"), "LINHA DE TRANSPORTE" },
                { m_Settings.GetUILocaleID("TransportLineVehicleNotification"), "Sem veículos" },

            };

            return entries;
        }

        public void Unload()
        {
        }
    }
}
