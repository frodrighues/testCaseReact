import * as React from 'react';
import * as ReactDOM from 'react-dom';
import SideMenu from './components/Navigation/SideMenu';
import { Col } from 'react-bootstrap';

ReactDOM.render(
    <div>
        <Col md={3}>
            <SideMenu />
        </Col>
        <Col md={9}>
            <h1>SITE</h1>
        </Col>
    </div>
    ,
    document.getElementById('root')
);
