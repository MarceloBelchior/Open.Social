import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public forecasts: TimeSheet[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
            this.forecasts = result.json() as TimeSheet[];
        }, error => console.error(error));
    }
}

interface TimeSheet {
    IniDay: any;
        EndDay: any;
        BreakFestIni :any; 
        BreakFestEnd: any;
        ExtendInit:any;
        ExtendEnd: any;
        CliendId: any;
        UserId: any;
        ProjectId: any;
        Comments: any;
        reg: any;
}
