// File: src/Localization/LocalePT_PT.cs
// Purpose: European Portuguese (pt-PT) strings for City Watchdog Options UI and notification panel text.

namespace CityWatchdog
{
    using Colossal;                   // IDictionarySource
    using System.Collections.Generic; // Dictionary and KeyValuePair

    public sealed class LocalePT_PT : IDictionarySource
    {
        private readonly Setting m_Settings;

        public LocalePT_PT(Setting setting)
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
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Debug" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.MoneyViewGroup), "Vista de dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificações" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Marco" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Converter gravação" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Atalhos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutDiagnostics), "DIAGNOSTICS" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "UTILIZAÇÃO" },

                // --- Money View ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyView)), "Vista de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyView)),
                    "Adiciona valores de tendência junto às setas de dinheiro e população da barra inferior.\\n" +
                    "É só uma indicação na barra; não altera dinheiro nem população." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyViewMode)), "Frequência da vista de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyViewMode)),
                    "Escolhe se a tendência da barra inferior mostra valores por hora ou por mês para dinheiro e população.\\n" +
                    "Mensal usa receita menos despesas do orçamento, e uma projeção de 24 h para a população." },
                { m_Settings.GetOptionLocaleID("MoneyViewModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("MoneyViewModeMonthly"), "Por mês (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo da dica de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Escolhe quanto detalhe aparece na dica ao passar sobre o dinheiro.\\n" +
                    "Compacto = padrão na primeira instalação.\\n"+
                    "<Mini> mostra só 2 valores líquidos para /mo e /h.\\n" +
                    "<Compacto> encurta valores grandes (15,21M em vez de 15 212 318).\\n" +
                    "<Dados completos> mostra valores longos e campos Total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeFullData"), "Dados completos" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipFontScale)), "Tamanho do texto do dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipFontScale)),
                    "Ajusta o <tamanho do texto> dos números da dica de dinheiro.\\n" +
                    "Padrão do jogo = 100%\\n" +
                    "<Padrão do mod = 120%>\\n" +
                    "Passa o rato sobre Dinheiro no fundo do ecrã.\\n"+
                    "Pedido por jogadores que têm dificuldade em ler dicas pequenas."

                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.PopulationTooltipFontScale)), "Tamanho do texto da população" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.PopulationTooltipFontScale)),
                    "Ajusta o <tamanho do texto> dos números da dica de população.\\n" +
                    "Padrão do jogo = 100%\\n" +
                    "<Padrão do mod = 120%>\\n" +
                    "Passa o rato sobre População no fundo do ecrã."   
                },

                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Valor do atalho de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Usa este valor com os atalhos Adicionar e Subtrair dinheiro.\\n" +
                    "<Padrão do mod = 40 000>\\n" +
                    "Não faz nada até usares o atalho para adicionar/subtrair dinheiro na cidade.\\n"+
                    "Para dinheiro automático, ativa Adicionar dinheiro automático."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)),
                    "Atalho para <Adicionar dinheiro> na cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Adicionar dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)),
                    "Atalho para <Subtrair dinheiro> na cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtrair dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoney)), "Adicionar dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoney)),
                    "Quando ativo [ ✓ ], o City Watchdog verifica o saldo enquanto a cidade está carregada.\\n" +
                    "- Se o saldo estiver <abaixo do limite>, \\n" +
                    "  adiciona o valor automático escolhido.\\n" +
                    "- Recomendo usar dinheiro manual com o atalho (<[> ou <]>) quando precisares" +
                    "  em vez da opção automática, mas ela fica aqui se quiseres."
                },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)), "Limite do dinheiro automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyThreshold)),
                    "Se Adicionar dinheiro automático estiver ativo e o saldo cair abaixo deste valor,\\n" +
                    "adiciona o valor automático escolhido." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AutomaticAddMoneyAmount)), "Valor automático" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AutomaticAddMoneyAmount)),
                    "Valor adicionado sempre que o automático dispara.\\n" +
                    "Escolhe um valor suficiente para pôr a cidade acima do limite." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinheiro inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Define o saldo inicial de uma nova cidade com <dinheiro limitado> ou da primeira cidade carregada,\\n" +
                    "depois volta ao padrão do jogo após aplicar.\\n" +
                    "Fica cinzento se uma cidade já estiver carregada.\\n" +
                    "Define antes de iniciar/carregar uma cidade → aplica uma vez → depois usa <Valor do atalho de dinheiro> ou <Adicionar dinheiro automático>." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },

                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar ícones de notificação" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Atalho> para a mesma ação do botão <[ALTERNAR TODOS]> no jogo.\\n" +
                    "Mostra ou oculta logo todos os ícones de notificação listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/ocultar todos os ícones" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/fechar painel de notificações" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Atalho> para abrir ou fechar o\\n" +
                    "<painel de notificações> na cidade.\\n" +
                    "Funciona como clicar no ícone no canto superior esquerdo."
                },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/fechar painel de notificações" },

                // --- Milestone selector ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.CustomMilestone)), "Seletor de marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.CustomMilestone)),
                    "Ativa antes de carregar ou iniciar uma cidade para desbloquear logo o marco escolhido.\\n" +
                    "Não pode ser ligado com uma cidade carregada, mas pode ser desligado se ficou ativo por engano.\\n" +
                    "O City Watchdog não desfaz marcos já gravados na cidade; usa uma gravação anterior se precisares." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MilestoneLevel)), "Marco" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MilestoneLevel)),
                    "Escolhe o nível de marco a desbloquear no próximo carregamento.\\n" +
                    "Só pode ser ajustado fora de uma cidade carregada e com [Seletor de marco] ativo [ ✓ ]." },

                // --- Save conversion ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)), "Conversor de dinheiro ilimitado" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConfirmUnlimitedMoneySaveConversion)),
                    "<Faz primeiro uma cópia da cidade>.\\n" +
                    "Converte uma cidade criada com Dinheiro ilimitado numa cidade normal com desafios de orçamento.\\n" +
                    "Ao ativar, desbloqueia <[Converter gravação com dinheiro ilimitado]> quando a cidade carregada é de <Dinheiro ilimitado>.\\n" +
                    "O City Watchdog não consegue desfazer esta conversão.\\n" +
                    "Se tens cidades normais, ignora isto; não é preciso." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)), "Converter cidade de dinheiro ilimitado para normal" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Para cidades iniciadas com <Dinheiro ilimitado>.\\n" +
                    "Com a cidade carregada, converte a gravação para orçamento normal com dinheiro limitado.\\n" +
                    "O botão fica <desativado/cinzento> exceto se a cidade carregada for de <Dinheiro ilimitado>\\n" +
                    "e <Conversor de dinheiro ilimitado> estiver LIGADO [ ✓ ].\\n" +
                    "Faz uma cópia e usa por tua conta; o City Watchdog não desfaz isto." },

                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ConvertUnlimitedMoneySave)),
                    "Converter esta cidade de Dinheiro ilimitado para dinheiro limitado normal?\\n" +
                    "Guarda uma cópia PRIMEIRO; o City Watchdog não desfaz isto.\\n" +
                    "Tens a certeza?" },

                // --- About tab ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Nome do mod" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.NameText)), "Nome apresentado deste mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Versão" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.VersionText)), "Versão atual do mod." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenParadox)), "Paradox Mods" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenParadox)), "Abrir a página do autor no Paradox Mods." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.WriteNotificationAuditLog)), "Debug Audit to Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.WriteNotificationAuditLog)),
                    "Not needed for normal gameplay.\n" +
                    "For testers and post-patch checks: writes a CityWatchdog.log report comparing live game notification prefabs with the notification icons City Watchdog currently controls." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Open Log" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Opens CityWatchdog.log if it exists.\n" +
                    "If the log file is missing, opens the Logs folder instead." },
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowUsage)), "Mostrar instruções" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowUsage)), "Mostrar ou ocultar as instruções abaixo." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UsageText)),
                    "<Painel de notificações>\\n" +
                    "1. Clica no botão City Watchdog (canto superior esquerdo) ou prime Shift+N para abrir o painel.\\n" +
                    "2. Ordena ASC/DESC.\\n" +
                    "3. Alternar todos liga/desliga rápido; ou expande uma secção para mudar ícones específicos.\\n" +
                    "4. Só mostra/oculta ícones; não corrige o problema da cidade.\\n\\n" +
                    "<Ajuda de dinheiro>\\n" +
                    "1. Adicionar/Subtrair dinheiro: usa o <Valor do atalho de dinheiro> padrão [ ou ].\\n" +
                    "2. O automático vigia o orçamento e adiciona dinheiro abaixo do limite.\\n" +
                    "3. A Vista de dinheiro adiciona números à barra de dinheiro/população e às dicas.\\n" +
                    "4. Converter gravação com dinheiro ilimitado é só para essas cidades e <não é reversível>.\\n\\n" +
                    "<Marco personalizado>\\n" +
                    "Define Dinheiro inicial e Marcos nas Opções antes de carregar ou iniciar uma cidade."
                },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Abrir o painel de ícones de notificação." },

                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Expande linhas; marcado mostra, vazio oculta.\\n" +
                    "Atalhos padrão: Shift+N painel, N alternar tudo, [ adicionar, ] subtrair.\\n" +
                    "Não corrige problemas; só limpa a confusão de ícones." },


                { m_Settings.GetUILocaleID("ToggleAll"), "ALTERNAR TODOS" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Expandir tudo" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Fechar tudo" },

                { m_Settings.GetUILocaleID("SortAscending"), "↑Ordenar ascendente" },
                { m_Settings.GetUILocaleID("SortDescending"), "↓Ordenar descendente" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "Mostrar/ocultar todos os ícones.\\n" +
                    "Cor: verde = tudo ligado; azul = misto; vermelho = tudo desligado." },

                // Tooltip labels.
                { m_Settings.GetUILocaleID("MoneyViewTooltipIncome"), "Receita:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipExpenses"), "Despesas:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipNet"), "Líquido:" },
                { m_Settings.GetUILocaleID("MoneyViewTooltipTotal"), "Total:" },
                { m_Settings.GetUILocaleID("PopulationTooltipCurrentTrend"), "Tendência:" },
                { m_Settings.GetUILocaleID("PopulationTooltipBirths"), "Nasc.:" },
                { m_Settings.GetUILocaleID("PopulationTooltipDeaths"), "Mortes:" },
                { m_Settings.GetUILocaleID("PopulationTooltipHomeless"), "Sem-abrigo:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedIn"), "Entradas:" },
                { m_Settings.GetUILocaleID("PopulationTooltipMovedOut"), "Saídas:" },

                // --- Electricity notifications ---
                { m_Settings.GetUILocaleID("Electricity"), "ELETRICIDADE" },
                { m_Settings.GetUILocaleID("ElectricityElectricityNotification"), "Eletricidade insuficiente" },
                { m_Settings.GetUILocaleID("ElectricityBottleneckNotification"), "Gargalo elétrico" },
                { m_Settings.GetUILocaleID("ElectricityBuildingBottleneckNotification"), "Mau fluxo elétrico" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughProductionNotification"), "Central sobrecarregada" },
                { m_Settings.GetUILocaleID("ElectricityTransformerNotification"), "Transformador sobrecarregado" },
                { m_Settings.GetUILocaleID("ElectricityNotEnoughConnectedNotification"), "Poucas linhas de saída ligadas" },
                { m_Settings.GetUILocaleID("ElectricityBatteryEmptyNotification"), "Bateria esgotada" },
                { m_Settings.GetUILocaleID("ElectricityLowVoltageNotConnected"), "Cabo elétrico não ligado" },
                { m_Settings.GetUILocaleID("ElectricityHighVoltageNotConnected"), "Linha elétrica não ligada" },

                // --- Water pipe notifications ---
                { m_Settings.GetUILocaleID("WaterPipe"), "TUBOS DE ÁGUA" },
                { m_Settings.GetUILocaleID("WaterPipeWaterNotification"), "Água insuficiente" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterNotification"), "Bomba de água poluída" },
                { m_Settings.GetUILocaleID("WaterPipeSewageNotification"), "Esgoto entupido" },
                { m_Settings.GetUILocaleID("WaterPipeWaterPipeNotConnectedNotification"), "Tubo de água não ligado" },
                { m_Settings.GetUILocaleID("WaterPipeSewagePipeNotConnectedNotification"), "Tubo de esgoto não ligado" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughWaterCapacityNotification"), "Instalação de água sobrecarregada" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSewageCapacityNotification"), "Instalação de esgoto sobrecarregada" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughGroundwaterNotification"), "Lençol freático muito baixo" },
                { m_Settings.GetUILocaleID("WaterPipeNotEnoughSurfaceWaterNotification"), "Nível da água muito baixo" },
                { m_Settings.GetUILocaleID("WaterPipeDirtyWaterPumpNotification"), "Bomba de água poluída" },

                // --- Building notifications ---
                { m_Settings.GetUILocaleID("Building"), "EDIFÍCIO" },
                { m_Settings.GetUILocaleID("BuildingAbandonedCollapsedNotification"), "Colapsado" },
                { m_Settings.GetUILocaleID("BuildingAbandonedNotification"), "Abandonado" },
                { m_Settings.GetUILocaleID("BuildingCondemnedNotification"), "Condenado" },
                { m_Settings.GetUILocaleID("BuildingTurnedOffNotification"), "Desativado" },
                { m_Settings.GetUILocaleID("BuildingHighRentNotification"), "Renda alta" },

                // --- Traffic notifications ---
                { m_Settings.GetUILocaleID("Traffic"), "TRÂNSITO" },
                { m_Settings.GetUILocaleID("TrafficBottleneckNotification"), "Engarrafamento" },
                { m_Settings.GetUILocaleID("TrafficDeadEndNotification"), "Beco sem saída" },
                { m_Settings.GetUILocaleID("TrafficRoadConnectionNotification"), "Estrada necessária" },
                { m_Settings.GetUILocaleID("TrafficTrackConnectionNotification"), "Via não ligada" },
                { m_Settings.GetUILocaleID("TrafficCarConnectionNotification"), "Sem acesso de carro" },
                { m_Settings.GetUILocaleID("TrafficShipConnectionNotification"), "Sem ligação aquática" },
                { m_Settings.GetUILocaleID("TrafficTrainConnectionNotification"), "Sem ligação ferroviária" },
                { m_Settings.GetUILocaleID("TrafficPedestrianConnectionNotification"), "Sem acesso pedonal" },
                { m_Settings.GetUILocaleID("TrafficBicycleConnectionNotification"), "Sem acesso de bicicletas" },

                // --- Company notifications ---
                { m_Settings.GetUILocaleID("Company"), "EMPRESA" },
                { m_Settings.GetUILocaleID("CompanyNoInputsNotification"), "Custos altos de recursos" },
                { m_Settings.GetUILocaleID("CompanyNoCustomersNotification"), "Clientes insuficientes" },

                // --- Work provider notifications ---
                { m_Settings.GetUILocaleID("WorkProvider"), "EMPREGADOR" },
                { m_Settings.GetUILocaleID("WorkProviderUneducatedNotification"), "Falta de mão de obra" },
                { m_Settings.GetUILocaleID("WorkProviderEducatedNotification"), "Falta de mão de obra qualificada" },

                // --- Disaster notifications ---
                { m_Settings.GetUILocaleID("Disaster"), "DESASTRE" },
                { m_Settings.GetUILocaleID("DisasterWeatherDamageNotification"), "Danos do clima" },
                { m_Settings.GetUILocaleID("DisasterWeatherDestroyedNotification"), "Destruído pelo clima" },
                { m_Settings.GetUILocaleID("DisasterWaterDamageNotification"), "Danos de água" },
                { m_Settings.GetUILocaleID("DisasterWaterDestroyedNotification"), "Destruído por inundação" },
                { m_Settings.GetUILocaleID("DisasterDestroyedNotification"), "Este edifício foi destruído" },

                // --- Fire notifications ---
                { m_Settings.GetUILocaleID("Fire"), "INCÊNDIO" },
                { m_Settings.GetUILocaleID("FireFireNotification"), "A arder" },
                { m_Settings.GetUILocaleID("FireBurnedDownNotification"), "Queimado" },

                // --- Garbage notifications ---
                { m_Settings.GetUILocaleID("Garbage"), "LIXO" },
                { m_Settings.GetUILocaleID("GarbageGarbageNotification"), "Lixo a acumular" },
                { m_Settings.GetUILocaleID("GarbageFacilityFullNotification"), "Instalação cheia" },

                // --- Healthcare notifications ---
                { m_Settings.GetUILocaleID("Healthcare"), "SAÚDE" },
                { m_Settings.GetUILocaleID("HealthcareAmbulanceNotification"), "À espera de ambulância" },
                { m_Settings.GetUILocaleID("HealthcareHearseNotification"), "À espera de carro funerário" },
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
                { m_Settings.GetUILocaleID("ResourceConsumerNoResourceNotification"), "Recursos insuficientes" },
                { m_Settings.GetUILocaleID("ResourceConnection"), "LIGAÇÃO DE RECURSOS" },
                { m_Settings.GetUILocaleID("ResourceConnectionWarningNotification"), "Linha de recursos não ligada" },
                { m_Settings.GetUILocaleID("Route"), "ROTA" },
                { m_Settings.GetUILocaleID("RoutePathfindNotification"), "Caminho falhou" },

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
