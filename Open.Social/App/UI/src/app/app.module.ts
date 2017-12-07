import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { TimeSheetComponent } from './pages/time-sheet/time-sheet.component';
import { AddTimeSheetComponent } from './Pages/add-time-sheet/add-time-sheet.component';


@NgModule({
  declarations: [
    AppComponent,
    TimeSheetComponent,
    AddTimeSheetComponent
    
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
