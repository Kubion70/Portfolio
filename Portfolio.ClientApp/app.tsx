import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { MyButton } from './components/MyButton';
declare let module: any;

export class Hello extends React.Component {
    render() {
        return (
            <React.Fragment>
                <h1>Welcome tffdddo123456 React!!</h1>
            </React.Fragment>
        );
    }
}

ReactDOM.render(<Hello />, document.getElementById('root'));

if (module.hot) {
    module.hot.accept();
}