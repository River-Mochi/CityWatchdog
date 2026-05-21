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
                { m_Settings.GetOptionTabLocaleID(Setting.AchievementsTab), "Conquistas" },
                { m_Settings.GetOptionTabLocaleID(Setting.Hotkeys), "Atalhos" },
                { m_Settings.GetOptionTabLocaleID(Setting.About), "Sobre" },
                { m_Settings.GetOptionTabLocaleID(Setting.Debug), "Depuração" },

                // --- Groups ---
                { m_Settings.GetOptionGroupLocaleID(Setting.Trends), "Rastreador de tendências" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Money), "Dinheiro" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Notifications), "Notificações" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Milestone), "Marco" },
                { m_Settings.GetOptionGroupLocaleID(Setting.SaveConversion), "Converter save" },
                { m_Settings.GetOptionGroupLocaleID(Setting.Achievements), "Conquistas" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AchievementTools), "Ferramentas avançadas" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AchievementDanger), "Redefinir conquistas" },
                { m_Settings.GetOptionGroupLocaleID(Setting.HotkeyActions), "Atalhos" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutInfo), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutLinks), "" },
                { m_Settings.GetOptionGroupLocaleID(Setting.AboutUsage), "USO" },

                // --- Trend Tracker ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendTracker)), "Rastreador de tendências" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendTracker)),
                    "Adiciona valores numéricos de tendência ao lado das setas vanilla de dinheiro e população na barra inferior.\n" +
                    "É apenas uma exibição leve da barra; não altera o dinheiro nem a população da cidade." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.TrendDisplayMode)), "Frequência da tendência" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.TrendDisplayMode)),
                    "Escolha se o texto de tendência da barra inferior mostra valores por hora ou mensais para dinheiro e população.\n" +
                    "Mensal usa receita menos despesas do orçamento para dinheiro, e uma projeção de 24 horas para população." },

                { m_Settings.GetOptionLocaleID("TrendDisplayModeHourly"), "Por hora (/h)" },
                { m_Settings.GetOptionLocaleID("TrendDisplayModeMonthly"), "Mensal (/mo)" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.MoneyTooltipMode)), "Estilo do tooltip de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.MoneyTooltipMode)),
                    "Escolha quantos detalhes aparecem no tooltip de dinheiro ao passar o cursor.\n" +
                    "<Mini> mostra apenas os dois valores líquidos de /mo e /h.\n" +
                    "<Compact> encurta valores grandes (15.21M em vez de 15,212,318).\n" +
                    "<Full size> mostra valores longos e campos de total." },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeMini"), "Mini" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeCompact"), "Compacto" },
                { m_Settings.GetOptionLocaleID("MoneyTooltipModeDefault"), "Tamanho completo" },


                // --- Money helpers ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ManualMoneyAmount)), "Valor do atalho de dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ManualMoneyAmount)),
                    "Use este valor com os atalhos Adicionar dinheiro e Subtrair dinheiro.\n" +
                    "Padrão = 40.000.\n" +
                    "Isto não faz nada a menos que o atalho seja usado dentro da cidade para adicionar/subtrair dinheiro.\n" +
                    "Para dinheiro automático, ative a opção Adicionar dinheiro automático." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Adicionar dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AddMoneyKeyboardBinding)), "Atalho para adicionar dinheiro dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.AddMoneyAction), "Adicionar dinheiro" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Subtrair dinheiro" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SubtractMoneyKeyboardBinding)), "Atalho para subtrair dinheiro dentro da cidade." },
                { m_Settings.GetBindingKeyLocaleID(Setting.SubtractMoneyAction), "Subtrair dinheiro" },

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
                    "Escolha um valor alto o bastante para deixar a cidade acima do limite." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.InitialMoney)), "Dinheiro inicial" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.InitialMoney)),
                    "Define o saldo inicial para uma nova cidade com <dinheiro limitado> ou para a primeira cidade carregada, depois volta para o padrão do jogo.\n" +
                    "Fica cinza se uma cidade já estiver carregada.\n" +
                    "Defina antes de iniciar/carregar uma cidade → aplica uma vez → depois use <Valor do atalho de dinheiro> ou <Adicionar dinheiro automático>." },

                { m_Settings.GetOptionLocaleID("GameDefault"), "Padrão do jogo" },


                // --- Notifications ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)), "Alternar ícones de notificação" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationsKeyboardBinding)),
                    "<Atalho> para a mesma ação do botão de ícone <[Toggle All]> no painel do jogo.\n" +
                    "Mostra ou oculta instantaneamente todos os ícones de notificação listados." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationsAction), "Mostrar/ocultar instantaneamente todos os ícones de notificação" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)), "Abrir/fechar painel de notificações" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ToggleNotificationPanelKeyboardBinding)),
                    "<Atalho> para abrir ou fechar o painel de notificações no jogo.\n" +
                    "Funciona como clicar no ícone superior esquerdo para abrir o painel completo." },
                { m_Settings.GetBindingKeyLocaleID(Setting.ToggleNotificationPanelAction), "Abrir/fechar painel de notificações" },


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
                    "Salve um backup PRIMEIRO; City Watchdog não pode desfazer isto.\n" +
                    "Tem certeza?" },


                // --- Achievements ---
                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementsEnabled)), "Ativar conquistas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementsEnabled)),
                    "Mantenha isto **ON [ ✓ ]** para permitir conquistas usando mods.\n" +
                    "O jogo não conta tarefas feitas no passado,\n" +
                    "então mantenha ativado e faça as tarefas normalmente para completar conquistas." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementNotes)),
                    "• <Ativado por padrão> sem usar os botões avançados abaixo.\n" +
                    "• Apenas mantenha ativado para completar conquistas naturalmente :)\n" +
                    "" },

                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementNotes)), "" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ShowAdvancedAchievementTools)), "Mostrar ferramentas avançadas" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ShowAdvancedAchievementTools)), "**Opcional:** para testar, limpar ou ativar uma conquista." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.SelectedAchievement)), "Conquista selecionada" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.SelectedAchievement)),
                    "Selecione uma conquista para alterar.\n" +
                    "<Não é necessário para o progresso normal de conquistas.>\n" +
                    "Use apenas se quiser redefinir/limpar conquistas ou desbloqueá-las sem fazer as tarefas." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.UnlockSelectedAchievement)), "Desbloquear selecionada" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UnlockSelectedAchievement)), "**Desbloqueia e conclui** a conquista selecionada." },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ClearSelectedAchievement)), "Limpar selecionada" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ClearSelectedAchievement)), "Marca a conquista selecionada como **não concluída**." },
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ClearSelectedAchievement)),
                    "LIMPAR / REDEFINIR esta conquista.\n\n" +
                    "Continuar?" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.AchievementToolsAdvisory)),
                    "<Ferramentas avançadas são opcionais>\n" +
                    "• Use para testes, reparos ou redefinir todas as conquistas.\n" +
                    "• Passe o mouse sobre qualquer botão para ver detalhes no painel direito." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.AchievementToolsAdvisory)), "Teste" },

                { m_Settings.GetOptionLabelLocaleID(nameof(Setting.ResetAllAchievements)), "REDEFINIR TUDO" },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.ResetAllAchievements)),
                    "Isto limpa todas as conquistas concluídas e permite começar de novo.\n" +
                    "**TENHA CUIDADO** ao usar **[REDEFINIR TUDO]**.\n" +
                    "Se usar por acidente, você pode recuperar conquistas concluídas com o botão [Desbloquear selecionada]." },

                // Confirmation modal Yes/No
                { m_Settings.GetOptionWarningLocaleID(nameof(Setting.ResetAllAchievements)),
                    "AVISO: REDEFINIR/LIMPAR todas as conquistas para status NÃO concluído.\n" +
                    "Continuar?" },


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
                    "1. Clique no botão City Watchdog (canto superior esquerdo) para abrir o painel.\n" +
                    "2. ASC/DESC para ordenar.\n" +
                    "3. Use Toggle All para configuração rápida, ou expanda uma seção para mudar ícones individuais.\n" +
                    "4. O City Watchdog só oculta ou mostra ícones; ele não corrige o problema real da cidade.\n\n" +
                    "<Ferramentas de dinheiro>\n" +
                    "1. Rastreador de tendências adiciona valores /h ou /mo ao lado de dinheiro e população na barra inferior.\n" +
                    "2. Adicionar e Subtrair dinheiro: use o <Valor do atalho de dinheiro>.\n" +
                    "3. Adicionar dinheiro automático observa o saldo da cidade enquanto ela está carregada e adiciona dinheiro abaixo do limite.\n" +
                    "4. Converter save de Dinheiro ilimitado é apenas para cidades iniciadas com Dinheiro ilimitado e <não pode ser revertido> pelo City Watchdog.\n\n" +
                    "<Marco personalizado>\n" +
                    "Defina Dinheiro inicial e selecione Marcos no menu de Opções antes de carregar ou iniciar uma cidade." },
                { m_Settings.GetOptionDescLocaleID(nameof(Setting.UsageText)), "" },

                // --- Notification panel common text ---
                { m_Settings.GetUILocaleID("EntryButtonTitle"), "CITY WATCHDOG" },
                { m_Settings.GetUILocaleID("EntryButtonDescription"), "Abrir o painel de ícones de notificação." },
                { m_Settings.GetUILocaleID("NotificationIconShowOrHide"),
                    "Expanda qualquer linha; marque [✓] para mostrar e desmarque para ocultar alertas.\n" +
                    "Isto não corrige problemas da cidade; apenas oculta a bagunça de ícones." },
                { m_Settings.GetUILocaleID("ToggleAll"), "Alternar tudo" },
                { m_Settings.GetUILocaleID("ExpandAll"), "Expandir tudo" },
                { m_Settings.GetUILocaleID("CollapseAll"), "Recolher todas as linhas" },
                { m_Settings.GetUILocaleID("SortAscending"), "ASC ↑" },
                { m_Settings.GetUILocaleID("SortDescending"), "DESC ↓" },
                { m_Settings.GetUILocaleID("SortOrderTooltip"), "Ordem de classificação" },
                { m_Settings.GetUILocaleID("ToggleAllTooltip"),
                    "Mostra/oculta todos os ícones.\n" +
                    "Cor: verde = tudo ligado; azul = misto; vermelho = tudo desligado." },
                { m_Settings.GetUILocaleID("TrendTooltipIncome"), "Receita:" },
                { m_Settings.GetUILocaleID("TrendTooltipExpenses"), "Despesas:" },
                { m_Settings.GetUILocaleID("TrendTooltipNet"), "Líquido:" },
                { m_Settings.GetUILocaleID("TrendTooltipTotal"), "Total:" },

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
