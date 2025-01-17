﻿/*
 * Copyright (C) 2011 mooege project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using Mooege.Core.GS.Universe;

namespace Mooege.Net.GS
{
    public sealed class GameServer : Server
    {
        private Universe GameUniverse;

        public GameServer()
        {
            GameUniverse=new Universe();

            this.OnConnect += ClientManager.OnConnect;
            this.OnDisconnect += ClientManager.OnDisconnect;
            this.DataReceived += GameServer_DataReceived;
            this.DataSent += (sender, e) => { };
        }

        void GameServer_DataReceived(object sender, ConnectionDataEventArgs e)
        {
            var connection = (Connection)e.Connection;
            ((GameClient)connection.Client).Parse(e);
        }

        public override void Run()
        {
            // we can't listen for port 1119 because D3 and the launcher (agent) communicates on that port through loopback.
            // so we change our default port and start D3 with a shortcut like so:
            //   "F:\Diablo III Beta\Diablo III.exe" -launch -auroraaddress 127.0.0.1:1345

            if (!this.Listen(Config.Instance.BindIP, Config.Instance.Port)) return;
            Logger.Info("Game-Server is listening on {0}:{1}...", Config.Instance.BindIP, Config.Instance.Port);
        }
    }
}