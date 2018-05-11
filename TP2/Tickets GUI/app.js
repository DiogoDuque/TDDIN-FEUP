import Electron, {app, BrowserWindow} from 'electron';

import Path from 'path';
import Url from 'url';

let mainWindow; // global reference to prevent garbage collecting on the window

function createWindow () {
  mainWindow = new BrowserWindow({width: 800, height: 600}); // Create the browser window.

  mainWindow.loadURL(Url.format({ // load the index.html of the app.
    pathname: Path.join(__dirname, './app/index.html'),
    protocol: 'file:',
    slashes: true,
  }));

  mainWindow.on('closed', function () { // Emitted when the window is closed.
    mainWindow = null;
  });
}

app.on('ready', createWindow);

app.on('window-all-closed', function () { // Quit when all windows are closed.
  if (process.platform !== 'darwin') {
    app.quit();
  }
})

app.on('activate', function () {
  // On OS X it's common to re-create a window in the app when the
  // dock icon is clicked and there are no other windows open.
  if (mainWindow === null) {
    createWindow();
  }
})
