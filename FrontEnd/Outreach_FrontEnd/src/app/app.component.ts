import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.styl']
})
export class AppComponent {
  title = 'OutreachFMSWeb';

  very_dissatisfied(event) { 
    debugger;
    //just added console.log which will display the event details in browser on click of the button.
    alert("Button is clicked");
    console.log(event);
 }
  dissatisfied(event) { 
    debugger;
    //just added console.log which will display the event details in browser on click of the button.
    alert("Button is clicked");
    console.log(event);
 }
 satisfied(event) { 
  debugger;
  //just added console.log which will display the event details in browser on click of the button.
  alert("Button is clicked");
  console.log(event);
}
Varysatisfied(event) { 
  debugger;
  //just added console.log which will display the event details in browser on click of the button.
  alert("Button is clicked");
  console.log(event);
}
}
